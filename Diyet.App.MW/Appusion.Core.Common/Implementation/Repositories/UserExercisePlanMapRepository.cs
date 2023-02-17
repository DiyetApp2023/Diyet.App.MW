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
    public class UserExercisePlanMapRepository : GenericRepository<UserExercisePlanMapEntity, DietDbContext>, IUserExercisePlanMapRepository
    {
        public UserExercisePlanMapRepository(DietDbContext context) : base(context)
        {
        }
    }
}
