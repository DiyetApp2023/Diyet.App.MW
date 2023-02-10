using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.Email;
using Appusion.Core.Common.Utility;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace Appusion.Core.Services.Mail
{
    /// <summary>
    /// MailService
    /// </summary>
    public class MailService : IMailService
    {
        private readonly MailHelper _mailHelper;
        public MailService(MailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        // https://blog.christian-schou.dk/send-emails-with-asp-net-core-with-mailkit/
        // https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
        /// <summary>
        /// SendEmailByMailKitSmtp
        /// </summary>
        /// <param name="mailRequest"></param>
        public async Task SendEmailByMailKitSmtp(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailHelper.MailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailHelper.MailSettings.Host, _mailHelper.MailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailHelper.MailSettings.Mail, _mailHelper.MailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        /// <summary>
        /// SendEmailByNetSmtp
        /// </summary>
        /// <param name="mailRequest"></param>
        public async Task SendEmailByNetSmtp(MailRequest mailRequest)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(mailRequest.ToEmail, mailRequest.ToName));
                message.From = new MailAddress(_mailHelper.MailSettings.Mail, _mailHelper.MailSettings.DisplayName);
                message.Subject = mailRequest.Subject;
                message.Body = mailRequest.Body;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                using (var client = new System.Net.Mail.SmtpClient(_mailHelper.MailSettings.Host, _mailHelper.MailSettings.Port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_mailHelper.MailSettings.Mail, _mailHelper.MailSettings.Password);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(message);
                }
            }
        }
    }
}
