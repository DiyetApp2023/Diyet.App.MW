using System;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserDietPlanDetailRepository : GenericRepository<UserDietPlanDetailEntity, DietDbContext>, IUserDietPlanDetailRepository
    {
        public UserDietPlanDetailRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserDietPlanDetailEntity> GetUserDietPlanDetailEntity(long userId, long planId, int mealId)
        {
            var userDietPlanDetailEntity = (from userDietPlanDetail in DbContext.UserDietPlanDetail
                                            join userDietPlanMap in DbContext.UserDietPlanMap on userDietPlanDetail.PlanId equals userDietPlanMap.PlanId
                                            where userDietPlanDetail.PlanId == planId && userDietPlanDetail.MealId == mealId && userDietPlanMap.UserId == userId
                                            select userDietPlanDetail).FirstOrDefault();
            return userDietPlanDetailEntity;
        }
    }
}

