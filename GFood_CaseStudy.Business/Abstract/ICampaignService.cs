using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<IEnumerable<Campaign>> GetList();
        IDataResult<IEnumerable<Campaign>> GetListByDate();
        IDataResult<Campaign> Add(Campaign campaign);
        IDataResult<Campaign> Update(Campaign campaign);
        IDataResult<Campaign> Delete(Campaign campaign);
    }
}
