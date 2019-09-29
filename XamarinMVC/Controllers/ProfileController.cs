using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using System.Web.Security;

namespace XamarinMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Profile
        public ActionResult Index()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            if (user.IsActive == false)
            {
                return RedirectToAction("Activate", "Account");
            }
            else
            {
                return View();
            }

        }
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string hashpass = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name && u.Password == hashpass);
            if (user != null)
            {
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                db.SaveChanges();
                if (user.Role.RoleName == "Admin")
                {
                    return Redirect("/Admin/Default");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ModelState.AddModelError("oldPassword", XamarinMVC.App_GlobalResources.Errors.OldPasswordIsIncurrect);
            }
            return View();
        }

        public  ActionResult AddToShoppingCart(int id)
        {
            var prod = db.Products.Find(id);
            ViewBag.myqty = prod.Quantity;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddToShoppingCart(ShoppingCartViewModel shoppingCart, int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var product = db.Products.Find(id);
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay== false);
            if (factor != null)
            {
                var detail = db.FactorDetail.FirstOrDefault(d => d.FactorId==factor.Id && d.ProductId==id);
                if (detail != null)
                {
                    detail.Count = shoppingCart.DetailCount + detail.Count;
                    detail.DetailPrice = product.Price;
                    db.SaveChanges();
                }
                else
                {
                    FactorDetail factorDetail = new FactorDetail()
                    {
                        FactorId = factor.Id,
                        ProductId = id,
                        Count = shoppingCart.DetailCount,
                        DetailPrice = product.Price
                    };
                    db.FactorDetail.Add(factorDetail);
                    db.SaveChanges();
                }
               
            }
            else
            {
                Random random = new Random();
                string str = random.Next(100000,999999).ToString();
            
                Factor newfactor = new Factor()
                {
                    UserId=user.Id,
                    Date="",
                    PayDate="",
                    IsPay=false,
                    Number=str,
                    PayNumber="",
                    PayTime="",
                    Price=0
                };
                db.Factors.Add(newfactor);
                db.SaveChanges();
                FactorDetail factorDetail = new FactorDetail()
                {
                    FactorId = factor.Id,
                    ProductId=id,
                    Count = shoppingCart.DetailCount,
                    DetailPrice = product.Price
                };
                db.FactorDetail.Add(factorDetail);
                db.SaveChanges();
            }
            return PartialView(shoppingCart);
        }
        public ActionResult ShoppingCart()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay == false);
            if (factor != null)
            {
                var detail = db.FactorDetail.Where(d => d.FactorId == factor.Id).ToList();
                return View(detail);
            }
            else
            {
                Response.Write("شما کالایی ثبت نام نکرده اید");
            }
            return View();
        }
    }
}