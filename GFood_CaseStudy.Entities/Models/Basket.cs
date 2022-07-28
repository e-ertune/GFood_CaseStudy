namespace GFood_CaseStudy.Entities.Models
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            BasketProducts = new HashSet<BasketProduct>();
            BasketCampaigns = new HashSet<BasketCampaign>();
        }

        public decimal Total { get; set; } = 0;

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
        public virtual ICollection<BasketCampaign> BasketCampaigns { get; set; }
    }
}
