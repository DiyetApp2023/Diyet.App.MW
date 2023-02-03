using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.Product
{
    public class ProductService : Base.ServiceBase, IProductService
    {
        private readonly ProductComponent _productComponent;
        public ProductService(ProductComponent productComponent) 
        {
            _productComponent = productComponent; 
        }

        public async Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetAllProductList()
        {
            return await this.RunSafelyAsync(() =>
            {
                return _productComponent.GetAllProductList().Result;
            });
        }

        public async Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetSearchedProductList(GetSearchedProductListRequestPackage getSearchedProductListRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _productComponent.GetSearchedProductList(getSearchedProductListRequestPackage).Result;
            });
        }

        public async Task<GenericServiceResult<List<GetSelectedProductUnitListResponsePackage>>> GetSelectedProductUnitList(GetSelectedProductUnitListRequestPackage getSelectedProductUnitListRequestPackage)
        {
            return await this.RunSafelyAsync(() =>
            {
                return _productComponent.GetSelectedProductUnitList(getSelectedProductUnitListRequestPackage).Result;
            });
        }
    }
}
