
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace ProjectCQRS.Abstractions
{
    public class EmailSender : IEmailSender
    {
        private readonly string _fromEmail, _fromName, _appPassword;
        public EmailSender(IConfiguration cfg)
        {
            _fromEmail = cfg["GMAIL_FROM_EMAIL"]!;
            _fromName = cfg["GMAIL_FROM_NAME"] ?? "EMU Rent A Car";
            _appPassword = cfg["GMAIL_APP_PASSWORD"]!;
        }
        public async Task SendAsync(string toEmail, string toName, string subject, string body)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(_fromName, _fromEmail));
            msg.To.Add(new MailboxAddress(toName ?? toEmail, toEmail));
            msg.Subject = string.IsNullOrWhiteSpace(subject) ? "Teşekkürler" : $"eMu: {subject}";
            msg.Body = new TextPart(TextFormat.Plain) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_fromEmail, _appPassword);
            await smtp.SendAsync(msg);
            await smtp.DisconnectAsync(true);
        }
    }
}
