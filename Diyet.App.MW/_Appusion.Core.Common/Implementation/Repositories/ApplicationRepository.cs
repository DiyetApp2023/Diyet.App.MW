using Appusion.Core.Common.Entities.Boa;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    internal class ApplicationRepository : GenericRepository<Application, BoaDbContext>, IApplicationRepository
    {
        public ApplicationRepository(BoaDbContext boaDbContext) : base(boaDbContext) { }

        public async Task<Application> GetApplication(int applicationId)
        {
            var result = DbContext.Application.Where(x => x.ApplicationId == applicationId).First();
            return result;
        }
    }
}
