
using Appusion.Core.BaseModels;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Appusion.Core.Services.Api.Controllers
{
    /// <summary>
    /// ProductController
    /// </summary>
    public class ProductController : System.Web.Http.ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mealService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// GetAllProductList
        /// </summary>
        /// <returns></returns>
        [Route("api/product/getallproductlist")]
        [HttpGet]
        public async Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetAllProductList()
        {
            return await _productService.GetAllProductList();
        }

        /// <summary>
        /// GetAllProductList
        /// </summary>
        /// <returns></returns>
        [Route("api/product/getsearchedproductlist")]
        [HttpPost]
        public async Task<GenericServiceResult<List<GetAllProductListResponsePackage>>> GetSearchedProductList([FromBody] GetSearchedProductListRequestPackage getSearchedProductListRequestPackage)
        {
            return await _productService.GetSearchedProductList(getSearchedProductListRequestPackage);
        }


        /// <summary>
        /// GetSelectedProductUnitList
        /// </summary>
        /// <param name="getSelectedProductUnitsRequestPackage"></param>
        /// <returns></returns>
        [Route("api/product/getselectedproductunitlist")]
        [HttpPost]
        public async Task<GenericServiceResult<List<GetSelectedProductUnitListResponsePackage>>> GetSelectedProductUnitList([FromBody] GetSelectedProductUnitListRequestPackage getSelectedProductUnitListRequestPackage)
        {
            return await _productService.GetSelectedProductUnitList(getSelectedProductUnitListRequestPackage);
        }

        // TODO : Bir kişinin her bir öğünde tüketeceği ürünler ve bu ürünlerin birimleri ve miktarlarını dönen servis
    }
}