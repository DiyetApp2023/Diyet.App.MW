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
    public class UserActivationEntityRepository : GenericRepository<UserActivationEntity, DietDbContext>, IUserActivationEntityRepository
    {
        public UserActivationEntityRepository(DietDbContext context) : base(context)
        {
        }

        public async Task SaveUserActivation(UserActivationEntity userActivation)
        {
           Insert(userActivation);
        }
    }
}
