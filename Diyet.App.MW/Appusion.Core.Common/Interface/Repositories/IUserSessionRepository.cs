using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserSessionRepository : IGenericRepository<UserSessionEntity>
    {
        Task<UserSessionEntity> GetUserSessionEntity(GetUserSessionEntityRequestPackage getUserSessionEntityRequestPackage);
    }
}
