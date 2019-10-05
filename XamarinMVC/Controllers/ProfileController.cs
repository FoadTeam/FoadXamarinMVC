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

        public ActionResult ShowAddress()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var address = db.Addresses.Where(u => u.UserId == user.Id).ToList();

            ViewBag.AddressId = new SelectList(address, "Id", "AddressText");
            return PartialView(address);
        }
        public ActionResult UpdateAddress(int? id)
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay == false);
            factor.AddressId = id;
            db.SaveChanges();
            return RedirectToAction("ShoppingCart");
        }

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

        public ActionResult AddToShoppingCart(int id)
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
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay == false);
            if (factor != null)
            {
                var detail = db.FactorDetail.FirstOrDefault(d => d.FactorId == factor.Id && d.ProductId == id);
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
                string str = random.Next(100000, 999999).ToString();

                var address = db.Addresses.FirstOrDefault(a => a.UserId == user.Id);
                int addressId = 0;
                if (address != null)
                {
                    addressId = address.Id;
                }

                Factor newfactor = new Factor()
                {
                    UserId = user.Id,
                    Date = "",
                    PayDate = "",
                    IsPay = false,
                    Number = str,
                    PayNumber = "",
                    PayTime = "",
                    Price = 0,
                    AddressId = addressId
                };
                db.Factors.Add(newfactor);
                db.SaveChanges();
                FactorDetail factorDetail = new FactorDetail()
                {
                    FactorId = newfactor.Id,
                    ProductId = id,
                    Count = shoppingCart.DetailCount,
                    DetailPrice = product.Price
                };
                db.FactorDetail.Add(factorDetail);
                db.SaveChanges();
            }
            return Redirect("/product/" + id + "/" + product.Name);

        }
        public ActionResult ShoppingCart()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay == false);
            if (factor != null)
            {
                var detail = db.FactorDetail.Where(d => d.FactorId == factor.Id).ToList();
                if (detail.Count > 0)
                {
                    return View(detail);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult DeleteSHhoppingList(int? id)
        {
            var factordetail = db.FactorDetail.Find(id);
            db.FactorDetail.Remove(factordetail);
            db.SaveChanges();
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult ShowFactors()
        {
            var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);
            var factor = db.Factors.FirstOrDefault(f => f.UserId == user.Id && f.IsPay == false);
            if (factor != null)
            {
                var detail = db.FactorDetail.Where(d => d.FactorId == factor.Id).ToList();
                if (detail.Count > 0)
                {
                    return View(detail);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }


    }
}