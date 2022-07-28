using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class BasketCampaign : IEntity
    {
        public int BasketId { get; set; }
        public int CampaignId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Basket? Basket { get; set; }
        public virtual Campaign? Campaign { get; set; }
    }
}
