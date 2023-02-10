using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserSessionRepository : GenericRepository<UserSessionEntity, DietDbContext>, IUserSessionRepository
    {
        public UserSessionRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserSessionEntity> GetUserSessionEntity(GetUserSessionEntityRequestPackage getUserSessionEntityRequestPackage)
        {
            var query = DbContext.UserSession.Where(x => x.AccessToken == getUserSessionEntityRequestPackage.AccessToken);
            if (getUserSessionEntityRequestPackage.UserId>0)
            {
                query.Where(x => x.AccessToken == getUserSessionEntityRequestPackage.AccessToken);
            }
           var userSessionEntity = query.FirstOrDefault();
           return userSessionEntity;
        }

        public async Task<UserSessionInfoResponsePackage> GetUserSessionInfo(UserSessionInfoRequestPackage userSessionInfoRequestPackage)
        {
            var userSessionInfo = (from user in DbContext.User
                    join userSession in DbContext.UserSession on user.Id equals userSession.UserId
                    join userSessionDetail in DbContext.UserSessionDetail on userSession.Id equals userSessionDetail.UserSessionId
                    where user.Id == userSessionInfoRequestPackage.UserId
                    select new UserSessionInfoResponsePackage
                    {
                        UserSessionEntity = userSession,
                        UserSessionDetailEntity = userSessionDetail
                    }).FirstOrDefault();
            return userSessionInfo;
        }
    }
}