using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class BasketCampaignDto : IDto
    {
        public int BasketId { get; set; }
        public int CampaignId { get; set; }
    }
}
