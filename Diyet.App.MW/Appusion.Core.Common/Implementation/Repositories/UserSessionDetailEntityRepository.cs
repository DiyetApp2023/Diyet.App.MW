using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserSessionDetailEntityRepository : GenericRepository<UserSessionDetailEntity, DietDbContext>, IUserSessionDetailEntityRepository
    {
        public UserSessionDetailEntityRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserSessionDetailEntity> GetUserSessionDetailEntity(RefreshRequestPackage refreshRequestPackage)
        {
            var userSessionDetailEntity = (from userSession in DbContext.UserSession
                     join userSessionDetail in DbContext.UserSessionDetail on userSession.Id equals userSessionDetail.UserSessionId
                     where userSession.AccessToken==refreshRequestPackage.AccessToken && userSessionDetail.RefreshToken==refreshRequestPackage.RefreshToken               
                     select userSessionDetail).FirstOrDefault();
            return userSessionDetailEntity;
        }
    }
}
