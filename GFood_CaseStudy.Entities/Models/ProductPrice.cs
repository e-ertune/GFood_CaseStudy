using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class ProductPrice : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public virtual Product? Product { get; set; }
    }
}
