using Misyon.Core.Common.Entities.Boa;
using Misyon.Core.Common.Implementation.DbContexts;
using Misyon.Core.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Misyon.Core.Common.Implementation.Repositories
{
    /// <summary>
    /// ParameterRepository
    /// </summary>
    public class ParameterRepository : GenericRepository<Parameter, BoaDbContext>, IParameterRepository
    {
        public ParameterRepository(BoaDbContext boaDbContext) : base(boaDbContext) { }

        /// <summary>
        /// GetParameterValues
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        public async Task<List<Parameter>> GetParameterValues(string paramType)
        {
            var result =  DbContext.Parameter.Where(x => x.ParamType == paramType).ToList();
            return result;
        }
    }
}