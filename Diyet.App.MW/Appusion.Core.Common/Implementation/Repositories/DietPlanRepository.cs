using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class DietPlanRepository : GenericRepository<DietPlanEntity, DietDbContext>, IDietPlanRepository
    {
        public DietPlanRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<DietPlanEntity> GetActiveDietPlanEntity(long userId)
        {
            var dietPlanEntity = (from dietPlan in DbContext.DietPlan
                                  join userDietPlanMap in DbContext.UserDietPlanMap on dietPlan.Id equals userDietPlanMap.PlanId
                                  where (dietPlan.IsActive && userDietPlanMap.UserId == userId)
                                  where(dietPlan.StartDate<= DateTime.UtcNow && dietPlan.EndDate>=DateTime.UtcNow)
                                  orderby dietPlan.CreateDate descending
                                  select dietPlan).FirstOrDefault();
            return dietPlanEntity;
        }

        public async Task<GetUserDietMealPlanResponsePackage> GetActiveUserDietMealPlan(long userId)
        {
            var userDietMealPlanResponsePackage = (from dietPlan in DbContext.DietPlan
                            join userDietPlanMap in DbContext.UserDietPlanMap on dietPlan.Id equals userDietPlanMap.PlanId
                            join userDietPlanDetail in DbContext.UserDietPlanDetail on dietPlan.Id equals userDietPlanDetail.PlanId
                            join meal in DbContext.Meal on userDietPlanDetail.MealId equals meal.Id
                            join userDietPlanMealDetailProductMap in DbContext.UserDietPlanMealDetailProductMap on userDietPlanDetail.Id equals userDietPlanMealDetailProductMap.UserDietPlanDetailId
                            join product in DbContext.Product on userDietPlanMealDetailProductMap.ProductId equals product.Id
                            where dietPlan.IsActive && userDietPlanMap.UserId == userId
                            where dietPlan.StartDate <= DateTime.UtcNow && dietPlan.EndDate >= DateTime.UtcNow
                            orderby dietPlan.CreateDate descending
                            select new GetUserDietMealPlanResponsePackage()
                            {
                                Id= userDietPlanDetail.Id,
                                PlanId = userDietPlanDetail.PlanId,
                                MealId = userDietPlanDetail.MealId,
                                StartTime = userDietPlanDetail.StartTime,
                                EndTime = userDietPlanDetail.EndTime,
                                EstimatedCalorie = userDietPlanDetail.EstimatedCalorie,
                            }).FirstOrDefault();

            userDietMealPlanResponsePackage.ProductDetails = (from userDietPlanMealDetailProductMap in DbContext.UserDietPlanMealDetailProductMap
                                                              where userDietPlanMealDetailProductMap.Id == userDietMealPlanResponsePackage.Id
                                                              select new List<UserDietPlanMealDetailProductMapRequestPackage>
                                                              {
                                                                  new UserDietPlanMealDetailProductMapRequestPackage
                                                                  {
                                                                       Id = userDietPlanMealDetailProductMap.Id,
                                                                       Order = userDietPlanMealDetailProductMap.Order,
                                                                       Quantity = userDietPlanMealDetailProductMap.Quantity,
                                                                       ProductId = userDietPlanMealDetailProductMap.ProductId,
                                                                       UnitId = userDietPlanMealDetailProductMap.UnitId
                                                                  }
                                                              }).ToList();
            return userDietMealPlanResponsePackage;
        }

        public async Task<List<DietPlanEntity>> GetAllDietPlanEntityList()
        {
            var dietPlanEntityList = DbContext.DietPlan.ToList();
            return dietPlanEntityList;
        }
    }
}