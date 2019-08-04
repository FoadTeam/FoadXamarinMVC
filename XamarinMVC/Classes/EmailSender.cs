using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using XamarinMVC.Models;

namespace XamarinMVC.Classes
{
    public class EmailSender
    {
        DatabaseContext db = new DatabaseContext();
        public void SendEmail(string to,string body,string subject)
        {
            var setting = db.Settings.FirstOrDefault();
                MailMessage mail = new MailMessage(setting.EmailUser, to, subject, body);
                SmtpClient client = new SmtpClient();
                client.Send(mail);
        }

       

    }
}