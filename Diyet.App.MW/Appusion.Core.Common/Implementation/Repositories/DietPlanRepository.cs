using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.Meal;
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
            var result = new GetUserDietMealPlanResponsePackage();
            var currentDietPlan = (from dietPlan in DbContext.DietPlan
                                   join userDietPlanMap in DbContext.UserDietPlanMap on dietPlan.Id equals userDietPlanMap.PlanId
                                   where dietPlan.IsActive && userDietPlanMap.UserId == userId
                                   where dietPlan.StartDate <= DateTime.UtcNow && dietPlan.EndDate >= DateTime.UtcNow
                                   orderby dietPlan.CreateDate descending
                                   select dietPlan).FirstOrDefault();
            if (currentDietPlan != null)
            {
                result.PlanId = currentDietPlan.Id;
                result.PlanName = currentDietPlan.PlanName;
                result.MealDetails = (from userDietPlanDetail in DbContext.UserDietPlanDetail
                                      join meal in DbContext.Meal on userDietPlanDetail.MealId equals meal.Id
                                      where userDietPlanDetail.PlanId == currentDietPlan.Id
                                      select new UserMealDetailResponsePackage
                                      {
                                          MealId = meal.Id,
                                          MealName = meal.MealName,
                                          StartTime = meal.StartTime,
                                          EndTime = meal.EndTime,
                                          EstimatedCalorie = userDietPlanDetail.EstimatedCalorie,
                                          ProductDetails = (from userDietPlanMealDetailProductMap in DbContext.UserDietPlanMealDetailProductMap
                                                            join product in DbContext.Product on userDietPlanMealDetailProductMap.ProductId equals product.Id
                                                            join productUnit in DbContext.ProductUnit on userDietPlanMealDetailProductMap.UnitId equals productUnit.Id
                                                            where userDietPlanMealDetailProductMap.UserDietPlanDetailId == userDietPlanDetail.Id
                                                            select new UserDietPlanMealDetailProductMapRequestPackage
                                                            {
                                                                Id = userDietPlanMealDetailProductMap.Id,
                                                                Order = userDietPlanMealDetailProductMap.Order,
                                                                Quantity = userDietPlanMealDetailProductMap.Quantity,
                                                                ProductId = userDietPlanMealDetailProductMap.ProductId,
                                                                ProductName = product.ProductName,
                                                                UnitName = productUnit.UnitName,
                                                                UnitId = userDietPlanMealDetailProductMap.UnitId
                                                            }).ToList()
                                      }).ToList();
            }
            return result;
        }

        public async Task<List<DietPlanEntity>> GetAllDietPlanEntityList()
        {
            var dietPlanEntityList = DbContext.DietPlan.ToList();
            return dietPlanEntityList;
        }
    }
}