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
    public class ActivityEntityRepository : GenericRepository<ActivityEntity, DietDbContext>, IActivityEntityRepository
    {
        public ActivityEntityRepository(DietDbContext context) : base(context)
        {
        }
    }
}
