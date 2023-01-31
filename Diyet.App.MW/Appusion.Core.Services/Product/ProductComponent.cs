using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.Product;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Services.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.Product
{
    public class ProductComponent : ComponentBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductComponent(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductListResponsePackage>> GetAllProductList()
        {
            var productEntityList = await _productRepository.GetAllProductList();
            return _mapper.Map<List<ProductEntity>, List<GetAllProductListResponsePackage>>(productEntityList);
        }

        public async Task<List<GetAllProductListResponsePackage>> GetSearchedProductList(GetSearchedProductListRequestPackage getSearchedProductListRequestPackage)
        {
            var searchedProductEntityList = await _productRepository.GetSearchedProductList(getSearchedProductListRequestPackage.SearchedProduct);
            return _mapper.Map<List<ProductEntity>, List<GetAllProductListResponsePackage>>(searchedProductEntityList);
        }
    }
}
