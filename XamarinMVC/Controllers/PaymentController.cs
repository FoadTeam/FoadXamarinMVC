using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinMVC.Models;
using XamarinMVC.Classes;
using System.Globalization;

namespace XamarinMVC.Controllers
{
    public class PaymentController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        PersianCalendar PC = new PersianCalendar();

        SMSSender sms = new SMSSender();
        // GET: Payment
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);

                var factor = db.Factors.FirstOrDefault(u => u.UserId == user.Id && u.IsPay == false);

                var details = db.FactorDetail.Where(d => d.FactorId == factor.Id).ToList();

                double SumFactor = 0;

                foreach (var item in details)
                {
                    var product = db.Products.Find(item.ProductId);

                    var factorDetail = db.FactorDetail.Find(item.Id);

                    factorDetail.DetailPrice = product.Price;

                    db.SaveChanges();

                    SumFactor += product.Price;
                }

                factor.Price = Convert.ToInt32(SumFactor);

                long orderID = Convert.ToInt64(factor.Number);
                long priceAmount = Convert.ToInt64(SumFactor);
                string additionalText = "خرید جدید در فروشگاه"; // توضیحات شما برای این تراکنش

                BankMellat bankmellat = new BankMellat();

                string resultRequest = bankmellat.bpPayRequest(orderID, priceAmount, additionalText);
                string[] StatusSendRequest = resultRequest.Split(',');

                if (int.Parse(StatusSendRequest[0]) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
                {
                    return RedirectToAction("RedirectVPOS", "Payment", new { id = StatusSendRequest[1] });
                }

                TempData["Message"] = bankmellat.DesribtionStatusCode(int.Parse(StatusSendRequest[0].Replace("_", " ")));
                return RedirectToAction("ShowError", "Payment");
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult RedirectVPOS(string id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "هیچ شماره پیگیری برای پرداخت از سمت بانک ارسال نشده است!";

                    return RedirectToAction("ShowError", "Payment");
                }
                else
                {
                    ViewBag.id = id;
                    return View();
                }
            }
            catch (Exception error)
            {
                TempData["Message"] = error + "متاسفانه خطایی رخ داده است، لطفا مجددا عملیات خود را انجام دهید در صورت تکرار این مشکل را به بخش پشتیبانی اطلاع دهید";

                return RedirectToAction("ShowError", "Payment");
            }
        }

        public ActionResult ShowError()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BankCallback()
        {
            bool Run_bpReversalRequest = false;
            long saleReferenceId = -999;
            long saleOrderId = -999;
            string resultCode_bpPayRequest;

            BankMellat bankmellat = new BankMellat();

            try
            {
                saleReferenceId = long.Parse(Request.Params["SaleReferenceId"].ToString());
                saleOrderId = long.Parse(Request.Params["SaleOrderId"].ToString());
                resultCode_bpPayRequest = Request.Params["ResCode"].ToString();

                //Result Code
                string resultCode_bpinquiryRequest = "-9999";
                string resultCode_bpSettleRequest = "-9999";
                string resultCode_bpVerifyRequest = "-9999";

                if (int.Parse(resultCode_bpPayRequest) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
                {
                    resultCode_bpVerifyRequest = bankmellat.VerifyRequest(saleOrderId, saleOrderId, saleReferenceId);

                    if (string.IsNullOrEmpty(resultCode_bpVerifyRequest))
                    {
                        resultCode_bpinquiryRequest = bankmellat.InquiryRequest(saleOrderId, saleOrderId, saleReferenceId);
                        if (int.Parse(resultCode_bpinquiryRequest) != (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
                        {
                            //the transactrion faild
                            TempData["Message"] = bankmellat.DesribtionStatusCode(int.Parse(resultCode_bpinquiryRequest.Replace("_", " ")));
                            Run_bpReversalRequest = true;
                        }
                    }

                    if ((int.Parse(resultCode_bpVerifyRequest) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
                        ||
                        (int.Parse(resultCode_bpinquiryRequest) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ))
                    {
                        resultCode_bpSettleRequest = bankmellat.SettleRequest(saleOrderId, saleOrderId, saleReferenceId);
                        if ((int.Parse(resultCode_bpSettleRequest) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
                            || (int.Parse(resultCode_bpSettleRequest) == (int)BankMellat.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Settle_ﺷﺪه_اﺳﺖ))
                        {
                            TempData["Message"] = "تراکنش شما با موفقیت انجام شد ";
                            TempData["Message"] += Environment.NewLine + " لطفا شماره پیگیری را یادداشت نمایید" + Environment.NewLine + saleReferenceId;
                        }
                        else
                        {
                            TempData["Message"] = bankmellat.DesribtionStatusCode(int.Parse(resultCode_bpSettleRequest.Replace("_", " ")));
                            Run_bpReversalRequest = true;
                        }

                        string strToday = PC.GetYear(DateTime.Now).ToString("0000") + "/" + PC.GetMonth(DateTime.Now).ToString("00") + "/" + PC.GetDayOfMonth(DateTime.Now).ToString("00");

                        var factor = db.Factors.FirstOrDefault(f => f.Number == saleOrderId.ToString());

                        factor.IsPay = true;
                        factor.PayNumber = saleReferenceId.ToString();
                        factor.PayDate = strToday;
                        factor.PayTime = DateTime.Now.ToShortTimeString();

                        db.SaveChanges();
                        var details = db.FactorDetail.Where(d => d.FactorId == factor.Id).ToList();
                        foreach (var item in details)
                        {
                            var product = db.Products.Find(item.ProductId);
                            product.Quantity = product.Quantity - item.Count;
                            db.SaveChanges();
                        }
                        var user = db.Users.FirstOrDefault(u => u.Mobile == User.Identity.Name);

                        var setting = db.Settings.FirstOrDefault();

                        try
                        {
                            if (setting.FactorIsSend)
                            {
                                sms.SendSMS(user.Mobile, "صورت حساب جدید شما در فروشگاه با مبلغ " + factor.Price.ToString());
                            }

                            if (setting.PayIsSend)
                            {
                                sms.SendSMS(user.Mobile, "صورت حساب جدید شما در فروشگاه با موفقیت پرداخت شد. شماره پیگیری شما  " + factor.Number.ToString());
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        TempData["Message"] = bankmellat.DesribtionStatusCode(int.Parse(resultCode_bpVerifyRequest.Replace("_", " ")));
                        Run_bpReversalRequest = true;
                    }
                }
                else
                {
                    TempData["Message"] = bankmellat.DesribtionStatusCode(int.Parse(resultCode_bpPayRequest)).Replace("_", " ");
                    Run_bpReversalRequest = true;
                }

                return RedirectToAction("ShowError", "Payment");
            }
            catch (Exception Error)
            {
                TempData["Message"] = "متاسفانه خطایی رخ داده است، لطفا مجددا عملیات خود را انجام دهید در صورت تکرار این مشکل را به بخش پشتیبانی اطلاع دهید";
                // Save and send Error for admin user
                Run_bpReversalRequest = true;
                return RedirectToAction("ShowError", "Payment");
            }
            finally
            {
                if (Run_bpReversalRequest) //ReversalRequest
                {
                    if (saleOrderId != -999 && saleReferenceId != -999)
                        bankmellat.bpReversalRequest(saleOrderId, saleOrderId, saleReferenceId);
                    // Save information to Database...
                }
            }
        }
    }
}