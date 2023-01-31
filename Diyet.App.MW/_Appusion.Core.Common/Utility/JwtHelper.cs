using Appusion.Core.Common.ParameterModels.Jwt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// JwtHelper
    /// </summary>
    public class JwtHelper
    {
        private readonly IOptions<JwtParameter> _jwtParameter;

        /// <summary>
        /// ctor
        /// </summary>
        public JwtHelper(IOptions<JwtParameter> jwtParameter)
        {
            _jwtParameter = jwtParameter;
        }

        /// <summary>
        /// GetJwtParameter
        /// </summary>
        public JwtParameter GetJwtParameter
        {
            get
            {
                return _jwtParameter.Value;
            }
        }
    }
}
