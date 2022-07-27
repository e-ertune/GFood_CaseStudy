using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IBasketCouponCodeService
    {
        IResult Use(BasketCouponCode basketCouponCode);
        IResult Cancel(BasketCouponCode basketCouponCode);
    }
}
