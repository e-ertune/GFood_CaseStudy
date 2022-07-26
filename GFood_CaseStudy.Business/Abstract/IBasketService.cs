using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<IEnumerable<Basket>> GetList();
        IDataResult<Basket> GetById(Guid id);
        IDataResult<Basket> Add(Basket basket);
        IDataResult<Basket> Update(Basket basket);
    }
}
