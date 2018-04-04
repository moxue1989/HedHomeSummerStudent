using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HedHome.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private static readonly string FromEmail = Environment.GetEnvironmentVariable("email_address");
        private static readonly string Password = Environment.GetEnvironmentVariable("email_password");
        private static readonly NetworkCredential NetworkCredential = new NetworkCredential(FromEmail, Password);

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return SendEmailAsync(new List<string> { email }, subject, message);
        }

        public Task SendEmailAsync(List<string> emailList, string subject, string message)
        {
            MailMessage msg = new MailMessage { From = new MailAddress(FromEmail) };
            foreach (string emailAddress in emailList)
            {
                msg.To.Add(emailAddress);
            }
            msg.Subject = subject;
            msg.Body = message;
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = NetworkCredential,
                Timeout = 20000
            };
            client.Send(msg);

            return Task.CompletedTask;
        }
    }
}
