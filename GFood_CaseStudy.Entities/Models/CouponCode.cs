namespace GFood_CaseStudy.Entities.Models
{
    public class CouponCode : BaseEntity
    {
        public CouponCode()
        {
            BasketCouponCodes = new HashSet<BasketCouponCode>();
        }
        public string Code { get; set; } = null!;
        public int Quota { get; set; }
        public decimal Discount { get; set; }
        public bool IsPercentage { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<BasketCouponCode> BasketCouponCodes { get; set; }
    }
}
