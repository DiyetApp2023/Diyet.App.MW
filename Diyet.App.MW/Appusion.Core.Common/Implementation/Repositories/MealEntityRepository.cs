using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class MealEntityRepository : GenericRepository<MealEntity, DietDbContext>, IMealEntityRepository
    {
        public MealEntityRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<List<MealEntity>> GetMealEntityList()
        {
            var mealEntityList = DbContext.Meal.Where(x=>x.IsActive).ToList();
            return mealEntityList;
        }
    }
}