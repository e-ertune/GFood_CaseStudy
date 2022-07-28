using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class CampaignGoalProduct : IEntity
    {
        public int CampaignGoalId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual CampaignGoal? CampaignGoal { get; set; }
        public virtual Product? Product { get; set; }
    }
}
