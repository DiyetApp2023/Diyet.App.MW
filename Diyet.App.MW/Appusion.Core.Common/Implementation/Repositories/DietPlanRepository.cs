using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
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
                              where (dietPlan.IsActive && userDietPlanMap.UserId==userId)
                              select dietPlan).FirstOrDefault();
            return dietPlanEntity;
        }

        public async Task<List<DietPlanEntity>> GetAllDietPlanEntityList()
        {
            var dietPlanEntityList = DbContext.DietPlan.ToList();
            return dietPlanEntityList;
        }
    }
}