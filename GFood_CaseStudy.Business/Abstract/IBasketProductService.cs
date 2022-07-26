using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IBasketProductService
    {
        IResult Update(BasketProduct basketProduct);
        IResult Delete(BasketProduct basketProduct);
    }
}
