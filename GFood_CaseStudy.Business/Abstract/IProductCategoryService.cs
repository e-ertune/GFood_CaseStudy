using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IProductCategoryService
    {
        IResult Add(ProductCategory productCategory);
        IResult Delete(ProductCategory productCategory);
    }
}
