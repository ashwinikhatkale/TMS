using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Sports.Helper
{
    public class EmailHelper
    {
        public static void SendEmail(string email,string subject, string body)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings.Get("Email:FromEmailAddress");
            var fromEmailPassword = ConfigurationManager.AppSettings.Get("Email:FromEmailPassword");
            var host = ConfigurationManager.AppSettings.Get("Email:Host");
            var port = ConfigurationManager.AppSettings.Get("Email:Port");

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(fromEmailAddress);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = body;
            smtp.Port = Convert.ToInt32(port);
            smtp.Host = host; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}