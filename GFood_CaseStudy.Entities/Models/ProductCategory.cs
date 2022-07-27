using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class ProductCategory : IEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Category? Category { get; set; }
    }
}
