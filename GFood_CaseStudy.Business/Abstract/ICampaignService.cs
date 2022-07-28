using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<IEnumerable<Campaign>> GetList();
        IDataResult<IEnumerable<Campaign>> GetListByDate(DateTime date);
        IDataResult<Campaign> GetById(int id);
        IDataResult<Campaign> Add(Campaign campaign);
        IDataResult<Campaign> Update(Campaign campaign);
        IDataResult<Campaign> Delete(Campaign campaign);

        IDataResult<Campaign> GetWithConditions(int campaignId);
        IDataResult<CampaignCondition> AddCondition(CampaignCondition campaignCondition);
        IDataResult<CampaignConditionProduct> AddProductToCondition(CampaignConditionProduct campaignConditionProduct);

        IDataResult<Campaign> GetWithGoals(int campaignId);
        IDataResult<CampaignGoal> AddGoal(CampaignGoal campaignGoal);
        IDataResult<CampaignGoalProduct> AddProductToGoal(CampaignGoalProduct campaignGoalProduct);

        IDataResult<IEnumerable<Campaign>> GetSuitableCampaigns(int basketId);
        IDataResult<Basket> UseCampaign(BasketCampaign basketCampaign);
    }
}
