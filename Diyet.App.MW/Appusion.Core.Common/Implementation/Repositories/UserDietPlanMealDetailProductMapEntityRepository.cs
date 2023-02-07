using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserDietPlanMealDetailProductMapEntityRepository : GenericRepository<UserDietPlanMealDetailProductMapEntity, DietDbContext>, IUserDietPlanMealDetailProductMapEntityRepository
    {
        public UserDietPlanMealDetailProductMapEntityRepository(DietDbContext context) : base(context)
        {
        }
    }
}
