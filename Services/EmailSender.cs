using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value ?? throw new ArgumentNullException(nameof(emailSettings));
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using (var smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port))
        {
            smtpClient.EnableSsl = _emailSettings.EnableTLS;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.EmailUser, _emailSettings.EmailPassword);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.EmailUser),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Ideally log the exception or handle it as per your error handling policy
                throw new InvalidOperationException("Failed to send email.", ex);
            }
        }
    }
}
