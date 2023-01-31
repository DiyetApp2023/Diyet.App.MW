using Appusion.Core.Common.RequestModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
