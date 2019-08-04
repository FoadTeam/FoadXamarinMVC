using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinMVC.Models;

namespace XamarinMVC.Classes
{
    
    public class SMSSender
    {
        DatabaseContext db = new DatabaseContext();
        SMSService.SendSMS SMS = new SMSService.SendSMS();
        public void SendSMS(string To,string Body)
        {
            var setting = db.Settings.FirstOrDefault();
            SMS.singleSMS(setting.SmsSender, setting.SmsUser, setting.SmsPassword, To, Body, 1);
            //SMS.singleSMS(17924, "msgadmin746", "1911855", To,Body, 1);
        }
    }
}