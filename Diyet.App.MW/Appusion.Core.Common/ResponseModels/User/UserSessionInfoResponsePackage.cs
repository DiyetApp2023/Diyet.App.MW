using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.ResponseModels.User
{
    public class UserSessionInfoResponsePackage
    {
        public UserSessionEntity UserSessionEntity { get; set; }

        public UserSessionDetailEntity UserSessionDetailEntity { get; set; }
    }
}
