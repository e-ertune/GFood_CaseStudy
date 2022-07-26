namespace GFood_CaseStudy.Entities.Models
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            BasketProducts = new HashSet<BasketProduct>();
        }

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
