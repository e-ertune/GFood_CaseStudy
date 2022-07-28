using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Aspects.Autofac.Caching;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheRemoveAspect("IProductService.Get", Priority = 1)]
        public IDataResult<Product> Add(Product product)
        {
            return new SuccessDataResult<Product>(data: _productDal.Add(product), message: "Ürün eklendi.");
        }

        [CacheRemoveAspect("IProductService.Get", Priority = 1)]
        public IDataResult<Product> Delete(Product product)
        {
            product.IsDeleted = true;
            return new SuccessDataResult<Product>(data: _productDal.Update(product), message: "Ürün güncellendi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<Product> GetByCode(string code)
        {
            return new SuccessDataResult<Product>(data: _productDal.Get(x => x.Code == code, includes: new[]
            {
                "ProductCategories"
            }), message: "Ürün getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(data: _productDal.Get(x => x.Id == id, includes: new[]
            {
                "ProductCategories",
                "ProductPrices"
            }), message: "Ürün getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Product>> GetList()
        {
            return new SuccessDataResult<IEnumerable<Product>>(data: _productDal.GetList(), message: "Ürün listesi getirildi.");
        }

        [CacheAspect(duration: 60, Priority = 1)]
        public IDataResult<IEnumerable<Product>> GetListByActivity(bool isActive)
        {
            return new SuccessDataResult<IEnumerable<Product>>(data: _productDal.GetList(x => x.IsActive == isActive, includes: new[]
            {
                "ProductCategories"
            }), message: "Ürün listesi getirildi.");
        }

        [CacheRemoveAspect("IProductService.Get", Priority = 1)]
        public IDataResult<Product> Update(Product product)
        {
            product.UpdatedAt = DateTime.Now;
            return new SuccessDataResult<Product>(data: _productDal.Update(product), message: "Ürün güncellendi.");
        }
    }
}
