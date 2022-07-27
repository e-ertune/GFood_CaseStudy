using GFood_CaseStudy.Core.Entities;

namespace GFood_CaseStudy.Entities.Models
{
    public class BasketCouponCode : IEntity
    {
        public Guid BasketId { get; set; }
        public Guid CouponCodeId { get; set; }

        public virtual Basket Basket { get; set; } = null!;
        public virtual CouponCode CouponCode { get; set; } = null!;
    }
}
