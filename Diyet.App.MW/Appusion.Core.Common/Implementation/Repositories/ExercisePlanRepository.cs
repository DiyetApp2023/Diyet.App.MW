using Appusion.Core.Common.Entities.ExercisePlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class ExercisePlanRepository : GenericRepository<ExercisePlanEntity, DietDbContext>, IExercisePlanRepository
    {
        public ExercisePlanRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<ExercisePlanEntity> GetActiveExercisePlanEntity(long userId)
        {
            var exercisePlanEntity = (from exercisePlan in DbContext.ExercisePlan
                                  join userExercisePlanMap in DbContext.UserExercisePlanMap on exercisePlan.Id equals userExercisePlanMap.ExercisePlanId
                                  where (exercisePlan.IsActive && userExercisePlanMap.UserId == userId)
                                  where (exercisePlan.StartDate <= DateTime.Now && exercisePlan.EndDate >= DateTime.Now)
                                  orderby exercisePlan.CreateDate descending
                                  select exercisePlan).FirstOrDefault();
            return exercisePlanEntity;
        }

        public async Task<List<ExerciseDefinitionEntity>> GetAllExerciseList()
        {
            return DbContext.ExerciseDefinition.ToList();
        }

        public async Task<List<ExerciseDefinitionEntity>> GetSearchedExerciseList(string searchedExercise)
        {
            return DbContext.ExerciseDefinition.Where(p => p.Name.StartsWith(searchedExercise)).ToList();
        }
    }
}
