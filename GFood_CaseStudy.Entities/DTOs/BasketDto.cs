using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class BasketDto : IDto
    {
        public BasketDto()
        {
            BasketProducts = new HashSet<BasketProductDto>();
            BasketCampaigns = new HashSet<BasketCampaignDto>();
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; } = 0;

        public virtual ICollection<BasketProductDto> BasketProducts { get; set; }
        public virtual ICollection<BasketCampaignDto> BasketCampaigns { get; set; }
    }
}
