using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.ResponseModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IProductRepository: IGenericRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetAllProductList();

        Task<List<ProductEntity>> GetSearchedProductList(string searchedProduct);
        
        Task<List<ProductUnitEntity>> GetSelectedProductUnitList(int productId);
    }
}