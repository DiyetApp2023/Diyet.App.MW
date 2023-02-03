using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    public class OtpHelper
    {
        public static string GenerateOtpCode
        {
            get
            {
                Random r = new Random();
                var otpCode = r.Next(100000, 999999).ToString();
                return otpCode;
            }
        }
    }
}