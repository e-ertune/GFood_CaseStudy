using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Caching;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        [CacheRemoveAspect("IBasketService.Get", Priority = 1)]
        public IDataResult<Basket> Add(Basket basket)
        {
            return new SuccessDataResult<Basket>(data: _basketDal.Add(basket), message: "Sepet oluşturuldu.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<Basket> GetById(Guid id)
        {
            return new SuccessDataResult<Basket>(data: _basketDal.Get(x => x.Id == id, includes: new[]
            {
                "BasketProducts",
                "BasketProducts.Product",
                "BasketProducts.Product.ProductPrices",
            }), message: "Sepet getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Basket>> GetList()
        {
            return new SuccessDataResult<IEnumerable<Basket>>(data: _basketDal.GetList(includes: new[]
            {
                "BasketProducts",
                "BasketProducts.Product",
            }), message: "Sepet listesi getirildi.");
        }

        [CacheRemoveAspect("IBasketService.Get", Priority = 1)]
        public IDataResult<Basket> Update(Basket basket)
        {
            basket.UpdatedAt = DateTime.Now;
            return new SuccessDataResult<Basket>(data: _basketDal.Update(basket), message: "Sepet güncellendi.");
        }
    }
}
