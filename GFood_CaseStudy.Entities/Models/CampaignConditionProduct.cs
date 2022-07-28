using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class CampaignConditionProduct : IEntity
    {
        public int CampaignConditionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual CampaignCondition? CampaignCondition { get; set; }
        public virtual Product? Product { get; set; }
    }
}
