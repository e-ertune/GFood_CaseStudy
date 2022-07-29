using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class CampaignConditionDto : IDto
    {
        public CampaignConditionDto()
        {
            CampaignConditionProducts = new HashSet<CampaignConditionProductDto>();
        }
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<CampaignConditionProductDto> CampaignConditionProducts { get; set; }
    }
}
