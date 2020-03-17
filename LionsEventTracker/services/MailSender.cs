using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LionsEventTracker.services
{
    public class MailSender
    {
        public static void sendEmail(string email, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("selulions123@gmail.com");
                mail.Subject = "Hello from Selu Lions!";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential
                ("selulions123@gmail.com", "mukunday123!");// Enter senders User name and password
                Console.WriteLine("Sending email .... ");
                smtp.Send(mail);
                Console.WriteLine("Email has been sent to " + email);
            }
            catch (Exception e)
            {
                Console.WriteLine("Email sending failed: " + e.Message);
            }

        }

    }

}

