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
        public IDataResult<Basket> GetById(int id)
        {
            var result = _basketDal.Get(x => x.Id == id, includes: new[]
            {
                "BasketProducts",
                "BasketProducts.Product",
                "BasketProducts.Product.ProductPrices",
                "BasketProducts.Product.ProductCategories",
                "BasketCampaigns",
                "BasketCampaigns.Campaign",
                "BasketCampaigns.Campaign.CampaignConditions",
                "BasketCampaigns.Campaign.CampaignConditions.CampaignConditionProducts",
                "BasketCampaigns.Campaign.CampaignConditions.CampaignConditionProducts.Product",
                "BasketCampaigns.Campaign.CampaignGoals",
                "BasketCampaigns.Campaign.CampaignGoals.CampaignGoalProducts",
                "BasketCampaigns.Campaign.CampaignGoals.CampaignGoalProducts.Product",
            });
            if (result != null)
            {
                return new SuccessDataResult<Basket>(data: result, message: "Sepet getirildi.");
            }
            return new ErrorDataResult<Basket>(data: result, message: "Sepet bulunamadı.");
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
