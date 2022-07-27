using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> Add(Category category)
        {
            return new SuccessDataResult<Category>(data: _categoryDal.Add(category), message: "Kategori eklendi.");
        }

        public IDataResult<Category> Delete(Category category)
        {
            category.IsDeleted = true;
            return new SuccessDataResult<Category>(data: _categoryDal.Update(category), message: "Kategori silindi.");
        }

        public IDataResult<Category> GetById(Guid id)
        {
            return new SuccessDataResult<Category>(data: _categoryDal.Get(x => x.Id == id), message: "Kategori getirildi.");
        }

        public IDataResult<IEnumerable<Category>> GetList()
        {
            return new SuccessDataResult<IEnumerable<Category>>(data: _categoryDal.GetList(x => !x.IsDeleted), message: "Kategori listesi getirildi.");
        }

        public IDataResult<Category> Update(Category category)
        {
            return new SuccessDataResult<Category>(data: _categoryDal.Update(category), message: "Kategori güncellendi.");
        }
    }
}
