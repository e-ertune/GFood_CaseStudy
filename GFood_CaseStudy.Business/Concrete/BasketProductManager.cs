using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Caching;
using GFood_CaseStudy.Core.Aspects.Autofac.Transaction;
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
        [TransactionScopeAspect(Priority = 2)]
        public IResult Update(BasketProduct basketProduct)
        {
            var basket = _basketService.GetById(basketProduct.BasketId);
            if (basket.IsSuccess)
            {
                if (basket.Data.BasketProducts.Any(x => x.ProductId == basketProduct.ProductId))
                {
                    var basketProductResult = basket.Data.BasketProducts.FirstOrDefault(x => x.ProductId == basketProduct.ProductId);
                    basketProductResult.Quantity += basketProduct.Quantity;
                    basketProductResult.UpdatedAt = DateTime.Now;
                    _ = _basketProductDal.Update(basketProductResult);
                    basket.Data.Total += basketProductResult.Quantity * basketProductResult.Price;
                }
                else
                {
                    basketProduct.Price = basket.Data.BasketProducts.FirstOrDefault(x => x.ProductId == basketProduct.ProductId).Product.ProductPrices.FirstOrDefault(x => !x.IsDeleted).Price;
                    var result = _basketProductDal.Add(basketProduct);
                    basket.Data.Total += basketProduct.Quantity * basketProduct.Price;
                }
                basket.Data.UpdatedAt = DateTime.Now;
                _ = _basketService.Update(basket.Data);
                return new SuccessResult(message: "Ürün sepete eklendi.");
            }
            return new ErrorResult(message: "Sepet bulunamadı.");
        }

        [CacheRemoveAspect(pattern: "IBasketService.Get", Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IResult Delete(BasketProduct basketProduct)
        {
            var basketProductResult = _basketProductDal.Get(x => x.ProductId == basketProduct.ProductId && x.BasketId == basketProduct.BasketId);
            if (basketProductResult != null)
            {
                var basket = _basketService.GetById(basketProduct.BasketId);
                basket.Data.Total -= basketProduct.Quantity * basketProduct.Price;
                _basketProductDal.Delete(basketProductResult);
                _ = _basketService.Update(basket.Data);
                return new SuccessResult(message: "Ürün sepetten silindi.");
            }
            return new ErrorResult(message: "Hata oluştu.");
        }
    }
}
