using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Transaction;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class BasketCouponCodeManager : IBasketCouponCodeService
    {
        private readonly IBasketCouponCodeDal _basketCouponCodeDal;
        private readonly IBasketService _basketService;
        private readonly ICouponCodeService _couponCodeService;

        public BasketCouponCodeManager(IBasketCouponCodeDal basketCouponCodeDal, IBasketService basketService, ICouponCodeService couponCodeService)
        {
            _basketCouponCodeDal = basketCouponCodeDal;
            _basketService = basketService;
            _couponCodeService = couponCodeService;
        }

        [TransactionScopeAspect(Priority = 2)]
        public IResult Cancel(BasketCouponCode basketCouponCode)
        {
            var basket = _basketService.GetById(basketCouponCode.BasketId);
            var couponCode = _couponCodeService.GetById(basketCouponCode.CouponCodeId);
            if (basket.Data.BasketCouponCodes.Any())
            {
                var total = basket.Data.BasketProducts.Sum(x => x.Price * x.Quantity);
                basket.Data.Total += couponCode.Data.IsPercentage ? total * couponCode.Data.Discount / 100 : couponCode.Data.Discount;
                _basketService.Update(basket.Data);
                _basketCouponCodeDal.Delete(basketCouponCode);
                return new SuccessResult(message: "Kupon iptal edildi.");
            }
            return new ErrorResult(message: "Kupon iptal edilemedi.");
        }

        [TransactionScopeAspect(Priority = 2)]
        public IResult Use(BasketCouponCode basketCouponCode)
        {
            var basket = _basketService.GetById(basketCouponCode.BasketId);
            var couponCode = _couponCodeService.GetById(basketCouponCode.CouponCodeId);
            if (!basket.Data.BasketCouponCodes.Any() && couponCode.Data.Quota > 0 && couponCode.Data.StartDate < DateTime.Now && couponCode.Data.EndDate > DateTime.Now)
            {
                basket.Data.Total -= couponCode.Data.IsPercentage ? basket.Data.Total * couponCode.Data.Discount / 100 : couponCode.Data.Discount;
                _basketService.Update(basket.Data);
                _basketCouponCodeDal.Add(basketCouponCode);
                return new SuccessResult(message: "Kupon kullanıldı.");
            }
            return new ErrorResult(message: "Kupon kullanılamadı.");
        }
    }
}
