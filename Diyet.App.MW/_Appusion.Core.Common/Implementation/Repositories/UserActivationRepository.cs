using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Misyon.Core.Common.Implementation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class UserActivationRepository : GenericRepository<UserActivation, DietDbContext>, IUserActivationRepository
    {
        public UserActivationRepository(DietDbContext context) : base(context)
        {
        }

        public void SaveUserActivation(UserActivation userActivation)
        {
           Insert(userActivation);
        }
    }
}
