using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.User
{
    /// <summary>
    /// ChangePasswordRequestPackage
    /// </summary>
    public class UserChangePasswordRequestPackage
    {
        public string EmailAddress { get; set; }

        public string OtpCode { get; set; }

        public string Password { get; set; }
    }
}
