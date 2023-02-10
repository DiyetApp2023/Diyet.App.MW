using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Enums;
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
    public class UserDailyActivityEntityRepository : GenericRepository<UserDailyActivityEntity, DietDbContext>, IUserDailyActivityEntityRepository
    {
        public UserDailyActivityEntityRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserDailyActivityEntity> GetUserDailyActivityEntity(long userId, ActivityType activityType)
        {
            var userDailyActivityEntity = DbContext.UserDailyActivity.Where(uda => uda.UserId==userId && uda.ActivityType==activityType 
                                          && uda.CreateDate== DateTime.UtcNow.Date).FirstOrDefault();
            return userDailyActivityEntity;
        }

        public async Task<List<GetUserDailyActivityResponsePackage>> GetUserDailyActivityList(long userId)
        {
            var userDailyActivityList = (from userDailyActivity in DbContext.UserDailyActivity
                     join activity in DbContext.Activity on (int)userDailyActivity.ActivityType equals activity.Id
                     where (userDailyActivity.UserId == userId && userDailyActivity.CreateDate == DateTime.UtcNow.Date)
                     select new GetUserDailyActivityResponsePackage
                     {
                         ActivityName = activity.Name,
                         ActivityType = userDailyActivity.ActivityType,
                         ActivityValue = userDailyActivity.ActivityValue
                     }).ToList();
            return userDailyActivityList;
        }
    }
}