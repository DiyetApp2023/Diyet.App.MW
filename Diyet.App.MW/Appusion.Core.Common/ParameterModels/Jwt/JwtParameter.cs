using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ParameterModels.Jwt
{
    /// <summary>
    /// JwtParameter
    /// </summary>
    public class JwtParameter
    {
        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string Issuer { get; set; }
    }
}