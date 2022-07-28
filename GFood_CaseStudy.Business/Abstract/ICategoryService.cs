using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IEnumerable<Category>> GetList();
        IDataResult<Category> GetById(int id);
        IDataResult<Category> Add(Category category);
        IDataResult<Category> Update(Category category);
        IDataResult<Category> Delete(Category category);
    }
}
