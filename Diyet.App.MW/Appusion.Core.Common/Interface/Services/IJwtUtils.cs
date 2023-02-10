using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.ResponseModels.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IJwtUtils
    {
        Task<TokenResponsePackage> GenerateAccessToken(UserEntity userEntity);

        Task<TokenResponsePackage> GenerateToken(UserEntity userEntity);

        Task<TokenResponsePackage> GenerateRefreshToken();

        Task<int?> ValidateAccessToken(string token);
    }
}