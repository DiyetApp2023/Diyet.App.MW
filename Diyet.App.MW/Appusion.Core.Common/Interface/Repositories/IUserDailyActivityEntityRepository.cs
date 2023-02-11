using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Enums;
using Appusion.Core.Common.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserDailyActivityEntityRepository: IGenericRepository<UserDailyActivityEntity>
    {
        Task<UserDailyActivityEntity> GetUserDailyActivityEntity(long userId, ActivityType activityType);

        Task<List<GetUserDailyActivityResponsePackage>> GetUserDailyActivityList(long userId, DateTime activityDate);
    }
}