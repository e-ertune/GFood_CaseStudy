using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class CouponCodeManager : ICouponCodeService
    {
        private readonly ICouponCodeDal _couponCodeDal;

        public CouponCodeManager(ICouponCodeDal couponCodeDal)
        {
            _couponCodeDal = couponCodeDal;
        }

        public IDataResult<CouponCode> Add(CouponCode couponCode)
        {
            return new SuccessDataResult<CouponCode>(data: _couponCodeDal.Add(couponCode), message: "Kupon kodu eklendi.");
        }

        public IDataResult<CouponCode> Delete(CouponCode couponCode)
        {
            couponCode.IsDeleted = true;
            return new SuccessDataResult<CouponCode>(data: _couponCodeDal.Update(couponCode), message: "Kupon kodu silindi.");
        }

        public IDataResult<CouponCode> GetByCode(string code)
        {
            return new SuccessDataResult<CouponCode>(data: _couponCodeDal.Get(x => x.Code == code), message: "Kupon kodu getirildi.");
        }

        public IDataResult<CouponCode> GetById(Guid id)
        {
            return new SuccessDataResult<CouponCode>(data: _couponCodeDal.Get(x => x.Id == id), message: "Kupon kodu getirildi.");
        }

        public IDataResult<IEnumerable<CouponCode>> GetList()
        {
            return new SuccessDataResult<IEnumerable<CouponCode>>(data: _couponCodeDal.GetList(), message: "Kupon kodları getirildi.");
        }

        public IDataResult<IEnumerable<CouponCode>> GetListByDate(DateTime date)
        {
            return new SuccessDataResult<IEnumerable<CouponCode>>(data: _couponCodeDal.GetList(x => x.StartDate < date && x.EndDate > date), message: "Kupon kodları getirildi.");
        }

        public IDataResult<CouponCode> Update(CouponCode couponCode)
        {
            return new SuccessDataResult<CouponCode>(data: _couponCodeDal.Update(couponCode), message: "Kupon kodu güncellendi.");
        }
    }
}
