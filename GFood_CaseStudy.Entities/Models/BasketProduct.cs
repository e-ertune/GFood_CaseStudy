using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class BasketProduct : IEntity
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;

        public virtual Product Product { get; set; } = null!;
        public virtual Basket Basket { get; set; } = null!;
    }
}
