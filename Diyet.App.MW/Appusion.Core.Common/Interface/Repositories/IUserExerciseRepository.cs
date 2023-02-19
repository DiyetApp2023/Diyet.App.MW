using Appusion.Core.Common.Entities.ExercisePlan;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IUserExerciseRepository : IGenericRepository<UserExerciseEntity>
    {
        Task<UserExerciseEntity> GetUserExerciseEntity(long userExercisePlanMapId, long exerciseId);
    }
}