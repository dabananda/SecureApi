using System.Net;
using System.Net.Mail;

namespace SecureApi.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var senderName = _config["SmtpSettings:SenderName"];
            var senderEmail = _config["SmtpSettings:SenderEmail"];
            var senderPassword = _config["SmtpSettings:Password"];

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            using (var smtpClient = new SmtpClient(_config["SmtpSettings:Server"], int.Parse(_config["SmtpSettings:Port"])))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
