using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinMVC.Classes
{
    
    public class SMSSender
    {
        SMSService.SendSMS SMS = new SMSService.SendSMS();
        public void SendSMS(string To,string Body)
        {
            SMS.singleSMS(17924, "msgadmin746", "1911855", To,Body, 1);
        }
    }
}