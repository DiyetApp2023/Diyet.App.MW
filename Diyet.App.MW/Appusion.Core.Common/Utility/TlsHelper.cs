using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// TlsHelper
    /// </summary>
    public class TlsHelper
    {
        /// <summary>
        /// SetDefaultTlsSettings
        /// </summary>
        public static void SetDefaultTlsSettings()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                                SecurityProtocolType.Tls11 |
                                                                SecurityProtocolType.Tls12 |
                                                                SecurityProtocolType.Tls13;
        }
    }
}