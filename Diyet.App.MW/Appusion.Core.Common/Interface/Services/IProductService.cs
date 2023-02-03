using Appusion.Core.BaseModels;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.ResponseModels.Product;

namespace Appusion.Core.Common.Interface.Services
{
    public interface  IProductService
    {
        Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetAllProductList();
        Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetSearchedProductList(GetSearchedProductListRequestPackage getSearchedProductListRequestPackage);
        Task<GenericServiceResult<List<GetSelectedProductUnitListResponsePackage>>> GetSelectedProductUnitList(GetSelectedProductUnitListRequestPackage getSelectedProductUnitListRequestPackage);
    }
}