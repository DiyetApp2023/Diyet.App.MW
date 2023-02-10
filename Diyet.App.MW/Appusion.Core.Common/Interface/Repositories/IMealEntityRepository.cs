using Appusion.Core.Common.Entities.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IMealEntityRepository : IGenericRepository<MealEntity>
    {
        Task<List<MealEntity>> GetDefaultScheduledMealList();
        Task<List<MealEntity>> GetMealEntityList();
    }
}
