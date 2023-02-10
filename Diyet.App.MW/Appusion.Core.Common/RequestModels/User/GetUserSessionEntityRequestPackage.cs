using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.User
{
    public class GetUserSessionEntityRequestPackage : UserSessionInfoRequestPackage
    {
        public string AccessToken { get; set; }
    }
}
