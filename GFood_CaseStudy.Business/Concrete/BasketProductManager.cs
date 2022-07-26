using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Caching;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class BasketProductManager : IBasketProductService
    {
        private readonly IBasketProductDal _basketProductDal;
        private readonly IBasketService _basketService;

        public BasketProductManager(IBasketProductDal basketProductDal, IBasketService basketService)
        {
            _basketProductDal = basketProductDal;
            _basketService = basketService;
        }

        [CacheRemoveAspect(pattern: "IBasketService.Get", Priority = 1)]
        public IResult Update(BasketProduct basketProduct)
        {
            var basketResult = _basketService.GetById(basketProduct.BasketId);
            if (basketResult.IsSuccess)
            {
                basketResult.Data.UpdatedAt = DateTime.Now;
                _ = _basketService.Update(basketResult.Data);

                if (basketResult.Data.BasketProducts.Any(x => x.ProductId == basketProduct.ProductId))
                {
                    var basketProductResult = basketResult.Data.BasketProducts.FirstOrDefault(x => x.ProductId == basketProduct.ProductId);
                    basketProductResult.Quantity += basketProduct.Quantity;
                    basketProductResult.UpdatedAt = DateTime.Now;
                    _ = _basketProductDal.Update(basketProductResult);
                }
                else
                {
                    var result = _basketProductDal.Add(basketProduct);
                }
                return new SuccessResult(message: "Ürün sepete eklendi.");
            }
            return new ErrorResult(message: "Sepet bulunamadı.");
        }

        [CacheRemoveAspect(pattern: "IBasketService.Get", Priority = 1)]
        public IResult Delete(BasketProduct basketProduct)
        {
            var basketProductResult = _basketProductDal.Get(x => x.ProductId == basketProduct.ProductId && x.BasketId == basketProduct.BasketId);
            if (basketProductResult != null)
            {
                _basketProductDal.Delete(basketProductResult);
                return new SuccessResult(message: "Ürün sepetten silindi.");
            }
            return new ErrorResult(message: "Hata oluştu.");
        }
    }
}
