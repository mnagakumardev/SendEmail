using System;
using System.Net;
using System.Net.Mail;
namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var to = new MailAddress("fromaddress@example.com");
            var from = new MailAddress("toaddress@example.com");

            var message = new MailMessage(from, to);
            message.Subject = "Test Email Subject";
            message.Body = "<h1> Test Email Message</h1>";
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("smtp_username", "smtp_password"),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
