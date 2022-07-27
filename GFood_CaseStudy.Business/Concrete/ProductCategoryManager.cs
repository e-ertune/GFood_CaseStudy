using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryDal _productCategoryDal;
        private readonly IProductService _productService;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal, IProductService productService)
        {
            _productCategoryDal = productCategoryDal;
            _productService = productService;
        }

        public IResult Add(ProductCategory productCategory)
        {
            var product = _productService.GetById(productCategory.ProductId);
            if (!product.Data.ProductCategories.Any(x => x.CategoryId == productCategory.CategoryId))
            {
                _productCategoryDal.Add(productCategory);
                return new SuccessResult(message: "Ürüne kategori tanımlandı.");
            }
            return new ErrorResult(message: "Ürün bu kategoride mevcut.");
        }

        public IResult Delete(ProductCategory productCategory)
        {
            var product = _productService.GetById(productCategory.ProductId);
            if (product.Data.ProductCategories.Any(x => x.CategoryId == productCategory.CategoryId))
            {
                _productCategoryDal.Delete(productCategory);
                return new SuccessResult(message: "Üründen kategori kaldırıldı.");
            }
            return new ErrorResult(message: "Ürün bu kategoride mevcut değil.");
        }
    }
}
