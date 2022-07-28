using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class ProductPriceManager : IProductPriceService
    {
        private readonly IProductPriceDal _productPriceDal;

        public ProductPriceManager(IProductPriceDal productPriceDal)
        {
            _productPriceDal = productPriceDal;
        }

        public IDataResult<ProductPrice> Add(ProductPrice productPrice)
        {
            var price = GetActiveByProductId(productPrice.ProductId);
            if (price.Data != null)
            {
                Delete(price.Data);
            }
            return new SuccessDataResult<ProductPrice>(data: _productPriceDal.Add(productPrice));
        }

        public IDataResult<ProductPrice> Delete(ProductPrice productPrice)
        {
            productPrice.IsDeleted = true;
            return new SuccessDataResult<ProductPrice>(data: _productPriceDal.Update(productPrice));
        }

        public IDataResult<ProductPrice> GetActiveByProductId(int productId)
        {
            return new SuccessDataResult<ProductPrice>(data: _productPriceDal.Get(x => !x.IsDeleted && x.ProductId == productId));
        }

        public IDataResult<ProductPrice> GetById(int id)
        {
            return new SuccessDataResult<ProductPrice>(data: _productPriceDal.Get(x => x.Id == id));
        }
    }
}
