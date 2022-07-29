using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class CampaignDto : IDto
    {
        public CampaignDto()
        {
            CampaignConditions = new HashSet<CampaignConditionDto>();
            CampaignGoals = new HashSet<CampaignGoalDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<CampaignConditionDto> CampaignConditions { get; set; }
        public virtual ICollection<CampaignGoalDto> CampaignGoals { get; set; }
    }
}
