using GFood_CaseStudy.Core.DataAccess.EntityFramework;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.DataAccess.Concrete.EntityFramework.Contexts;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.DataAccess.Concrete.EntityFramework
{
    public class CouponCodeDal : EfEntityRepositoryBase<CouponCode, GFoodContext>, ICouponCodeDal
    {
    }
}
