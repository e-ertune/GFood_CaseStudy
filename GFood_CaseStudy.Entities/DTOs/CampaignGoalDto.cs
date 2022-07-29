using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class CampaignGoalDto : IDto
    {
        public CampaignGoalDto()
        {
            CampaignGoalProducts = new HashSet<CampaignGoalProductDto>();
        }
        public int CampaignId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; } = false;

        public virtual ICollection<CampaignGoalProductDto> CampaignGoalProducts { get; set; }
    }
}
