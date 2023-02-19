using Appusion.Core.Common.Base;
using Appusion.Core.Common.Entities.ExercisePlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserExerciseRepository : GenericRepository<UserExerciseEntity, DietDbContext>, IUserExerciseRepository
    {
        public UserExerciseRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<UserExerciseEntity> GetUserExerciseEntity(long userExercisePlanMapId, long exerciseId)
        {
                var userExerciseEntity = DbContext.UserExercise.Where(ue => ue.UserExercisePlanMapId == userExercisePlanMapId && ue.ExerciseId == exerciseId).FirstOrDefault();
                return userExerciseEntity;
        }
    }
}