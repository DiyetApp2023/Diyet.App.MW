using Appusion.Core.Common.ParameterModels.Email;
using Appusion.Core.Common.ParameterModels.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// MailHelper
    /// </summary>
    public class MailHelper
    {
        private readonly IOptions<MailSetting> _mailSetting;
        const string HeaderKeyName = "activationCode";
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// ctor
        /// </summary>
        public MailHelper(IHttpContextAccessor httpContextAccessor, IOptions<MailSetting> mailSetting)
        {
            _mailSetting= mailSetting;
            _httpContextAccessor= httpContextAccessor;
        }

        /// <summary>
        /// GetMailSettings
        /// </summary>
        public MailSetting MailSettings
        {
            get
            {
                return _mailSetting.Value ;
            }
        }
    }
}
