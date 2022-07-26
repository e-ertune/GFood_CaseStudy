namespace GFood_CaseStudy.Entities.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            BasketProducts = new HashSet<BasketProduct>();
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
