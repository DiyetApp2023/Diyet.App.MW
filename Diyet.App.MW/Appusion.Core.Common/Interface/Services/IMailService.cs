using Appusion.Core.Common.RequestModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    /// <summary>
    /// IMailService
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// SendEmailByMailKitSmtp
        /// </summary>
        /// <param name="mailRequest"></param>
        Task SendEmailByMailKitSmtp(MailRequest mailRequest);

        /// <summary>
        /// SendEmailByNetSmtp
        /// </summary>
        /// <param name="mailRequest"></param>
        Task SendEmailByNetSmtp(MailRequest mailRequest);
    }
}