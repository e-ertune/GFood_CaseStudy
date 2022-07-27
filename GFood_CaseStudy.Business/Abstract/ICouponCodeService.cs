using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface ICouponCodeService
    {
        IDataResult<CouponCode> GetById(Guid id);
        IDataResult<CouponCode> GetByCode(string code);
        IDataResult<IEnumerable<CouponCode>> GetList();
        IDataResult<IEnumerable<CouponCode>> GetListByDate(DateTime date);
        IDataResult<CouponCode> Add(CouponCode couponCode);
        IDataResult<CouponCode> Update(CouponCode couponCode);
        IDataResult<CouponCode> Delete(CouponCode couponCode);
    }
}
