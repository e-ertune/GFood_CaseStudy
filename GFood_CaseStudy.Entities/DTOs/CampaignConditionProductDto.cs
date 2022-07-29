using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class CampaignConditionProductDto : IDto
    {
        public int Id { get; set; }
        public int CampaignConditionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual ProductDto? Product { get; set; }
    }
}
