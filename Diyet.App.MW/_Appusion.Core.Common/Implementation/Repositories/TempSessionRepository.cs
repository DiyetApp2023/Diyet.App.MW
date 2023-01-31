using Misyon.Core.Common.Entities.Misyon;
using Misyon.Core.Common.Implementation.DbContexts;
using Misyon.Core.Common.Interface.Repositories;

namespace Misyon.Core.Common.Implementation.Repositories
{
    public class TempSessionRepository : GenericRepository<TempSession, BoaDbContext>, ITempSessionRepository
    {
        public TempSessionRepository(BoaDbContext boaDbContext) : base(boaDbContext) { }

        public async Task SaveTempSession(TempSession tempSession)
        {
            Insert(tempSession);
        }
    }
}
