namespace GFood_CaseStudy.Entities.Models
{
    public class CampaignCondition : BaseEntity
    {
        public CampaignCondition()
        {
            CampaignConditionProducts = new HashSet<CampaignConditionProduct>();
        }
        public int CampaignId { get; set; }
        public decimal Amount { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual ICollection<CampaignConditionProduct> CampaignConditionProducts { get; set; }
    }
}
