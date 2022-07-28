using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<IEnumerable<Product>> GetList();
        IDataResult<IEnumerable<Product>> GetListByActivity(bool isActive);
        IDataResult<Product> GetById(int id);
        IDataResult<Product> GetByCode(string code);
        IDataResult<Product> Add(Product product);
        IDataResult<Product> Delete(Product product);
        IDataResult<Product> Update(Product product);
    }
}
