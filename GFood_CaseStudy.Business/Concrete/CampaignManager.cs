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

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
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

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Campaign>> GetList()
        {
            return new SuccessDataResult<IEnumerable<Campaign>>(data: _campaignDal.GetList(), message: "Kampanyalar getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Campaign>> GetListByDate()
        {
            return new SuccessDataResult<IEnumerable<Campaign>>(data: _campaignDal.GetList(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now), message: "Kampanyalar getirildi.");
        }

        [CacheRemoveAspect("ICampaignService.Get", Priority = 1)]
        public IDataResult<Campaign> Update(Campaign campaign)
        {
            return new SuccessDataResult<Campaign>(data: _campaignDal.Update(campaign), message: "Kampanya güncellendi.");
        }
    }
}
