using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.ResponseModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity, DietDbContext>, IProductRepository
    {
        public ProductRepository(DietDbContext context) : base(context)
        {
        }

        public async Task<List<ProductEntity>> GetAllProductList()
        {
            return DbContext.Product.ToList();
        }

        public async Task<List<ProductEntity>> GetSearchedProductList(string searchedProduct)
        {
            return DbContext.Product.Where(p=>p.ProductName.StartsWith(searchedProduct)).ToList();
        }
    }
}
