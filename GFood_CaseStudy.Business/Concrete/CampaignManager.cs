using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Caching;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignDal _campaignDal;
        private readonly ICampaignConditionDal _campaignConditionDal;
        private readonly ICampaignConditionProductDal _campaignConditionProductDal;
        private readonly ICampaignGoalDal _campaignGoalDal;
        private readonly ICampaignGoalProductDal _campaignGoalProductDal;
        private readonly IBasketService _basketService;
        private readonly IProductPriceService _productPriceService;

        public CampaignManager(ICampaignDal campaignDal, ICampaignConditionDal campaignConditionDal, ICampaignConditionProductDal campaignConditionProductDal, ICampaignGoalDal campaignGoalDal, ICampaignGoalProductDal campaignGoalProductDal, IBasketService basketService, IProductPriceService productPriceService)
        {
            _campaignDal = campaignDal;
            _campaignConditionDal = campaignConditionDal;
            _campaignConditionProductDal = campaignConditionProductDal;
            _campaignGoalDal = campaignGoalDal;
            _campaignGoalProductDal = campaignGoalProductDal;
            _basketService = basketService;
            _productPriceService = productPriceService;
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<Campaign> Add(Campaign campaign)
        {
            return new SuccessDataResult<Campaign>(data: _campaignDal.Add(campaign), message: "Kampanya oluşturuldu.");
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<Campaign> Delete(Campaign campaign)
        {
            campaign.IsDeleted = true;
            return new SuccessDataResult<Campaign>(data: _campaignDal.Update(campaign), message: "Kampanya silindi.");
        }

        public IDataResult<Campaign> GetById(int id)
        {
            return new SuccessDataResult<Campaign>(data: _campaignDal.Get(x => x.Id == id), message: "Kampanya getirildi.");
        }

        public IDataResult<Campaign> GetWithConditions(int campaignId)
        {
            var campaign = _campaignDal.Get(x => x.Id == campaignId, includes: new[]
            {
                "CampaignConditions",
                "CampaignConditions.CampaignConditionProducts"
            });
            if (campaign != null)
            {
                return new SuccessDataResult<Campaign>(data: campaign, message: "Kampanya, koşullarıyla birlikte getirildi.");
            }
            return new ErrorDataResult<Campaign>(data: campaign, message: "Kampanya bulunamadı.");
        }

        public IDataResult<Campaign> GetWithGoals(int campaignId)
        {
            var campaign = _campaignDal.Get(x => x.Id == campaignId, includes: new[]
            {
                "CampaignGoals",
                "CampaignGoals.CampaignGoalProducts"
            });
            if (campaign != null)
            {
                return new SuccessDataResult<Campaign>(data: campaign, message: "Kampanya, koşullarıyla birlikte getirildi.");
            }
            return new ErrorDataResult<Campaign>(data: campaign, message: "Kampanya bulunamadı.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Campaign>> GetList()
        {
            return new SuccessDataResult<IEnumerable<Campaign>>(data: _campaignDal.GetList(filter: x => !x.IsDeleted && x.StartDate < DateTime.Now && x.EndDate > DateTime.Now, includes: new[]
            {
                "CampaignConditions",
                "CampaignConditions.CampaignConditionProducts",
                "CampaignConditions.CampaignConditionProducts.Product",
                "CampaignGoals",
                "CampaignGoals.CampaignGoalProducts",
                "CampaignGoals.CampaignGoalProducts.Product",
            }), message: "Kampanyalar getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Campaign>> GetListByDate(DateTime date)
        {
            return new SuccessDataResult<IEnumerable<Campaign>>(data: _campaignDal.GetList(x => x.StartDate < date && x.EndDate > date), message: "Kampanyalar getirildi.");
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<Campaign> Update(Campaign campaign)
        {
            return new SuccessDataResult<Campaign>(data: _campaignDal.Update(campaign), message: "Kampanya güncellendi.");
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<CampaignCondition> AddCondition(CampaignCondition campaignCondition)
        {
            return new SuccessDataResult<CampaignCondition>(data: _campaignConditionDal.Add(campaignCondition));
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<CampaignConditionProduct> AddProductToCondition(CampaignConditionProduct campaignConditionProduct)
        {
            return new SuccessDataResult<CampaignConditionProduct>(data: _campaignConditionProductDal.Add(campaignConditionProduct));
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<CampaignGoal> AddGoal(CampaignGoal campaignGoal)
        {
            return new SuccessDataResult<CampaignGoal>(data: _campaignGoalDal.Add(campaignGoal));
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<CampaignGoalProduct> AddProductToGoal(CampaignGoalProduct campaignGoalProduct)
        {
            return new SuccessDataResult<CampaignGoalProduct>(data: _campaignGoalProductDal.Add(campaignGoalProduct));
        }

        public IDataResult<IEnumerable<Campaign>> GetSuitableCampaigns(int basketId)
        {
            var campaigns = GetList().Data;
            var basket = _basketService.GetById(basketId).Data;
            var suitableCampaigns = new List<Campaign>();
            foreach (var campaign in campaigns)
            {                
                if (IsSuitable(basket, campaign))
                {
                    suitableCampaigns.Add(campaign);
                }
            }
            if (suitableCampaigns.Any())
            {
                return new SuccessDataResult<IEnumerable<Campaign>>(data: suitableCampaigns, message: "Kullanılabilecek kampanyalar getirildi.");
            }
            return new ErrorDataResult<IEnumerable<Campaign>>(data: Enumerable.Empty<Campaign>(), message: "Kullanılabilecek kampanya bulunamadı.");
        }

        public IDataResult<Basket> UseCampaign(BasketCampaign basketCampaign)
        {
            var basket = _basketService.GetById(basketCampaign.BasketId).Data;
            var campaign = GetById(basketCampaign.CampaignId).Data;
            if (IsSuitable(basket, campaign))
            {
                foreach (var goal in campaign.CampaignGoals)
                {
                    if (goal.CampaignGoalProducts.Any())
                    {
                        foreach (var product in goal.CampaignGoalProducts)
                        {
                            decimal price = _productPriceService.GetActiveByProductId(product.ProductId).Data.Price;
                            basket.BasketProducts.Add(new BasketProduct
                            {
                                ProductId = product.ProductId,
                                BasketId = basket.Id,
                                CreatedAt = DateTime.Now,
                                Price = goal.IsPercentage ? (price * (100 - goal.Amount) / 100) : (price - goal.Amount),
                                Quantity = product.Quantity
                            });
                            basket.Total += (goal.IsPercentage ? (price * (100 - goal.Amount) / 100) : (price - goal.Amount)) * product.Quantity;
                        }
                    }
                    else
                    {
                        basket.Total -= goal.IsPercentage ? basket.Total * goal.Amount / 100 : goal.Amount;
                    }
                    _basketService.Update(basket);
                }
                return new SuccessDataResult<Basket>(data: basket, message: "Kampanya kullanıldı.");
            }
            return new ErrorDataResult<Basket>(data: basket, message: "Bu kampanya sepetle uyumsuzdur.");
        }

        private bool IsSuitable(Basket basket, Campaign campaign)
        {
            bool suitable = true;
            foreach (var condition in campaign.CampaignConditions)
            {
                if (condition.Amount == 0 && condition.CampaignConditionProducts.Any())
                {
                    foreach (var product in condition.CampaignConditionProducts)
                    {
                        if (basket.BasketProducts.Any(x => x.ProductId == product.ProductId && x.Quantity >= product.Quantity))
                        {
                            continue;
                        }
                        else
                        {
                            suitable = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (basket.Total >= condition.Amount)
                    {
                        continue;
                    }
                    else
                    {
                        suitable = false;
                        break;
                    }
                }
            }
            return suitable;
        }
    }
}
