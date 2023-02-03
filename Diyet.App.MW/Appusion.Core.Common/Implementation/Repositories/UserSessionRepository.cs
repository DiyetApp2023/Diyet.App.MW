using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.User;
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
            var userSessionEntity = DbContext.UserSession.Where(x => x.UserId== getUserSessionEntityRequestPackage.UserId && x.JwtToken == 
                                                                getUserSessionEntityRequestPackage.JwtToken).FirstOrDefault();
            return userSessionEntity;
        }
    }
}