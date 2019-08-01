using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace XamarinMVC.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }

 


        private void SetCulture(string cultureCode)
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

        public ActionResult Language()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Language(FormCollection collection)
        {

            string language = collection["ddlLanguage"];
            SetCulture(language);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}