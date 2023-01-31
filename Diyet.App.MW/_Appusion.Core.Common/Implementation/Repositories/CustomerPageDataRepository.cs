using Misyon.Core.Common.Entities.Misyon;
using Misyon.Core.Common.Implementation.DbContexts;
using Misyon.Core.Common.Interface.Repositories;


namespace Misyon.Core.Common.Implementation.Repositories
{
    public class CustomerPageDataRepository : GenericRepository<CustomerPageData, BoaDbContext>, ICustomerPageDataRepository
    {
        public CustomerPageDataRepository(BoaDbContext boaDbContext) : base(boaDbContext) { }

        /// <summary>
        /// GetCustomerPageData
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public async Task<List<CustomerPageData>> GetCustomerPageData(long applicationId)
        {
            var result = DbContext.CustomerPageData.Where(x => x.ApplicationId == applicationId).ToList();
            return result;
        }

        /// <summary>
        /// SaveCustomerPageData
        /// </summary>
        /// <param name="customerPageData"></param>
        /// <returns></returns>
        public async Task SaveCustomerPageData(CustomerPageData customerPageData)
        {
            Insert(customerPageData);
        }
    }
}
