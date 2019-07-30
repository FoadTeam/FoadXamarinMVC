using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace XamarinMVC.Classes
{
    public class EmailSender
    {
        public void SendEmail(string to,string body,string subject)
        {
                MailMessage mail = new MailMessage("foad.menbari@live.com", to, subject, body);
                SmtpClient client = new SmtpClient();
                client.Send(mail);
        }

       

    }
}