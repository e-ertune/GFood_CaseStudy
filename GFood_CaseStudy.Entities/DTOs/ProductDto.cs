using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.DTOs
{
    public class ProductDto : IDto
    {
        public ProductDto()
        {
            ProductPrices = new HashSet<ProductPriceDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public virtual ICollection<ProductPriceDto> ProductPrices { get; set; }
    }
}
