using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.Jwt
{
    public class RefreshRequestPackage
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
