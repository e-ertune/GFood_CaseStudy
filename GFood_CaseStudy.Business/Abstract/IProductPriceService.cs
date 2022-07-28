using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Abstract
{
    public interface IProductPriceService
    {
        IDataResult<ProductPrice> GetById(int id);
        IDataResult<ProductPrice> GetActiveByProductId(int productId);
        IDataResult<ProductPrice> Add(ProductPrice productPrice);
        IDataResult<ProductPrice> Delete(ProductPrice productPrice);        
    }
}
