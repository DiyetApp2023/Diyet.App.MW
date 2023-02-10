using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserSessionDetailEntityRepository : IGenericRepository<UserSessionDetailEntity>
    {
        Task<UserSessionDetailEntity> GetUserSessionDetailEntity(RefreshRequestPackage refreshRequestPackage);
    }
}
