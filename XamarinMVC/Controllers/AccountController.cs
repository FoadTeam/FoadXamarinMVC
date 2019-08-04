using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using System.Web.Security;
using XamarinMVC.Classes;
using System.Net.Mail;
using System.Web.Services.Description;
using System.Net;

namespace XamarinMVC.Controllers
{
    public class AccountController : Infrastructure.BaseController
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Language(string collection)
        {

            //string language = collection["ddlLanguage"];
            //SetCulture(language);
            string str = Request.Params["btn1"];


            SetCulture(str);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public void SetCulture(string cultureCode)
        {

            var cookieCultureLanguage = new HttpCookie("UserLanguage")
            {
                Value = cultureCode
            };

            Response.Cookies.Set(cookieCultureLanguage);

            //Sets  Culture for Current thread  
            Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR");

            //Ui Culture for Localized text in the UI  
            Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo(cultureCode);

        }
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if(!db.users.Any(x => x.Mobile == register.Mobile))
                {
                    string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5");
                    Random rnd = new Random();
                    int myrnd = rnd.Next(100000, 900000);
                    User user = new User()
                    {
                        RoleId = db.Roles.Max(r => r.Id),
                        Mobile = register.Mobile,
                        Password = hash,
                        Code = myrnd.ToString()
                    };
                    db.users.Add(user);
                    db.SaveChanges();
                    SMSSender sms = new SMSSender();
                    sms.SendSMS(register.Mobile, XamarinMVC.App_GlobalResources.Texts.RegisterSMS+ Environment.NewLine + myrnd.ToString());
                    return Redirect("index");
                }
                else
                {
                    ModelState.AddModelError("Mobile", XamarinMVC.App_GlobalResources.Errors.RepeatMobile );
                }

            }
            return View(register);
        }
        public  ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                string myhash = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = db.users.FirstOrDefault(m => m.Mobile ==login.Mobile && m.Password==myhash);
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(login.Mobile, true);
                    if (user.IsActive == true)
                    {


                        if (user.Role.RoleName == "Admin")
                        {
                            return Redirect("/Admin/Default/Index");
                        }
                        else
                        {
                            return RedirectToAction("index", "profile");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Activate");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", XamarinMVC.App_GlobalResources.Errors.FailedLogin);
                }
            }
            return View();
        }

        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Activate(ActivateViewModel activate)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.FirstOrDefault(u => u.Mobile == User.Identity.Name && u.Code== activate.Code);
                if(user != null)
                {
                    Random rnd = new Random();
                    int myrnd = rnd.Next(100000, 900000);
                    
                    user.IsActive = true;
                    user.Code = myrnd.ToString();
                    db.SaveChanges();
                    return RedirectToAction("index","Profile");
                }
                else
                {
                    ModelState.AddModelError("code", XamarinMVC.App_GlobalResources.Errors.ActivationCodeError);
                }
            }


            return View(activate);
        }
        public ActionResult CheckMobile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckMobile(CheckMobileViewModel checkMobile)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.FirstOrDefault(u => u.Mobile == checkMobile.Mobile);
                if(user != null)
                {
                    SMSSender sms = new SMSSender();
                    MailMessage mail = new MailMessage("foad.menbari@live.com","foad.menbari@gmail.com", XamarinMVC.App_GlobalResources.Texts.ActivisionCode, user.Code);
                    SmtpClient client = new SmtpClient();
                    client.Send(mail);
                    sms.SendSMS(user.Mobile, " "+ XamarinMVC.App_GlobalResources.Texts.ActivisionCode + ": "+ user.Code);
                    return RedirectToAction("ForgetPassword");
                }
                else
                {
                    ModelState.AddModelError("Mobile", XamarinMVC.App_GlobalResources.Errors.CheckMobile);
                }
            }
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordViewModel forgetPassword)
        {
            if (ModelState.IsValid)
            {
                string myhash = FormsAuthentication.HashPasswordForStoringInConfigFile(forgetPassword.Password, "MD5");
                var user = db.users.FirstOrDefault(u => u.Code == forgetPassword.Code);
                if(user != null)
                {
                    Random rnd = new Random();
                    int myrnd = rnd.Next(100000, 900000);
                    user.Code = myrnd.ToString();
                    user.Password = myhash;
                    db.SaveChanges();
                    return RedirectToAction("login");

                }
                else
                {
                    ModelState.AddModelError("Code", XamarinMVC.App_GlobalResources.Errors.ActivationCodeError);
                }
            }

            return View(forgetPassword);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("Login");
        }

    }
}