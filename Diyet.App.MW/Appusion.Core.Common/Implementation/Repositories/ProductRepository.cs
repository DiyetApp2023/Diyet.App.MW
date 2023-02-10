using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.User;
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
            return  DbContext.Product.ToList();
        }

        public async Task<List<ProductEntity>> GetSearchedProductList(string searchedProduct)
        {
            return  DbContext.Product.Where(p=>p.ProductName.StartsWith(searchedProduct)).ToList();
        }

        public async Task<List<ProductUnitEntity>> GetSelectedProductUnitList(int productId)
        {
            var productUnitEntity = (from product in DbContext.Product
                              join productUnitMap in DbContext.ProductUnitMap on product.Id equals productUnitMap.ProductId
                              join productUnit in DbContext.ProductUnit on productUnitMap.UnitId equals productUnit.Id
                              where (product.Id == productId)
                              select productUnit).ToList();
            return productUnitEntity;
        }
    }
}