using Appusion.Core.Common.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IJwtUtils
    {
        public string GenerateToken(UserEntity userEntity);
        public int? ValidateToken(string token);
    }
}