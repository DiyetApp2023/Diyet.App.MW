using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.ExercisePlan;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IExercisePlanRepository : IGenericRepository<ExercisePlanEntity>
    {
        Task<ExercisePlanEntity> GetActiveExercisePlanEntity(long userId);
        Task<List<ExerciseDefinitionEntity>> GetAllExerciseList();
        Task<List<ExerciseDefinitionEntity>> GetSearchedExerciseList(string searchedExercise);
    }
}
