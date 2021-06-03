using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Business
{
    public class MailSender : INotificationSender
    {
        public void SendMessage(string email, string message)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("niidevops12345@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Dear customer";
                mail.Body = "<p> Your status is updated!</p>" +
                    "<p> '" + message + "'</p>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("niidevops12345@gmail.com", "(h:;Q78tm#[7]kZ[");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
