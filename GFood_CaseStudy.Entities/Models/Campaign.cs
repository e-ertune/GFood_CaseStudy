namespace GFood_CaseStudy.Entities.Models
{
    public class Campaign : BaseEntity
    {
        public Campaign()
        {
            CampaignConditions = new HashSet<CampaignCondition>();
            CampaignGoals = new HashSet<CampaignGoal>();
            BasketCampaigns = new HashSet<BasketCampaign>();
        }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<CampaignCondition> CampaignConditions { get; set; }
        public virtual ICollection<CampaignGoal> CampaignGoals { get; set; }
        public virtual ICollection<BasketCampaign> BasketCampaigns { get; set; }
    }
}
