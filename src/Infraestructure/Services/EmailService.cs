using Microsoft.Extensions.Configuration;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Attachment = System.Net.Mail.Attachment;

namespace Prome.Viaticos.Server.Infraestructure.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client;
        private readonly IConfiguration _configuration;

        public EmailService(
        IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(Email email)
        {
            //TODO:
            await this.SendEmailBySendGridAsync(email);
            //this.InitConfiguration();
            //var EmailToSend = this.FillMessage(email);
            //await this._client.SendMailAsync(EmailToSend);
        }

        private MailMessage FillMessage(Email email)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_configuration["SMTP:fromMailMailer"])
            };

            mail.To.Clear();
            mail.Body = email.BodyMessage.ToString();
            mail.IsBodyHtml = true;
            mail.Subject = email.Subject;

            foreach (var addressTo in email.SendToEmailList)
                mail.To.Add(addressTo);

            foreach (var addressTo in email.SendCCToEmailList)
                mail.CC.Add(addressTo);

            foreach (var addressTo in email.SendBCCToEmailList)
                mail.Bcc.Add(addressTo);

            foreach (var strAttachmentPath in email.AttachmentsPath)
                mail.Attachments.Add(new Attachment(strAttachmentPath));

            return mail;
        }

        private void InitConfiguration()
        {
            var user = _configuration["SMTP:networkCredentialUserNameMailer"];
            var password = _configuration["SMTP:networkCredentialPasswordMailer"];

            this._client = new SmtpClient
            {
                Port = int.Parse(_configuration["SMTP:portMailer"]),
                Host = _configuration["SMTP:hostMailer"],
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true
            };

            this._client.UseDefaultCredentials = false;
            this._client.Credentials = new NetworkCredential(user, password);
        }

        public async Task SendEmailBySendGridAsync(Email email)
        {
            var emailFron = _configuration["SMTP:fromMailMailer"];
            var apiKey = _configuration["SMTP:Api"];
            var emailTo = _configuration["SMTP:toMailMailer"];

            var client = new SendGridClient(apiKey);
            var from = new SendGrid.Helpers.Mail.EmailAddress(emailFron);
            var to = new SendGrid.Helpers.Mail.EmailAddress(emailTo);
            var htmlContent = email.BodyMessage;
            var textPlain = email.BodyMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, textPlain, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
