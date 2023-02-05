using System;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserDietPlanDetailRepository : GenericRepository<UserDietPlanDetailEntity, DietDbContext>, IUserDietPlanDetailRepository
    {
        public UserDietPlanDetailRepository(DietDbContext context) : base(context)
        {
        }
    }
}

