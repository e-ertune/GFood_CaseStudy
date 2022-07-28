namespace GFood_CaseStudy.Entities.Models
{
    public class CampaignGoal : BaseEntity
    {
        public CampaignGoal()
        {
            CampaignGoalProducts = new HashSet<CampaignGoalProduct>();
        }
        public int CampaignId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; } = false;

        public virtual Campaign? Campaign { get; set; }
        public virtual ICollection<CampaignGoalProduct> CampaignGoalProducts { get; set; }
    }
}
