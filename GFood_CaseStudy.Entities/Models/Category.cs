namespace GFood_CaseStudy.Entities.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
            ProductCategories = new HashSet<ProductCategory>();
        }
        public int? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category>? SubCategories { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
