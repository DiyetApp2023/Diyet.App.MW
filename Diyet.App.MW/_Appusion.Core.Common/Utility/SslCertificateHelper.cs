using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// SslCertificateHelper
    /// </summary>
    internal class SslCertificateHelper
    {
        /// <summary>
        /// SetDefaultSslCertificateSettings
        /// </summary>
        public static void SetDefaultSslCertificateSettings()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate,
              X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        }
    }
}