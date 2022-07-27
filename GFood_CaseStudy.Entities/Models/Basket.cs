namespace GFood_CaseStudy.Entities.Models
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            BasketProducts = new HashSet<BasketProduct>();
            BasketCouponCodes = new HashSet<BasketCouponCode>();
        }

        public decimal Total { get; set; } = 0;

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
        public virtual ICollection<BasketCouponCode> BasketCouponCodes { get; set; }
    }
}
