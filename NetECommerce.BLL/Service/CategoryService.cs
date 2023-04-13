using NetECommerce.BLL.Abstract;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.Service
{
    public class CategoryService : ICategoryService
    {

        private IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }





        public string CreateCategory(Category category)
        {
            try
            {
                return _categoryRepository.Create(category);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string DeleteCategory(Category category)
        {
            try
            {
                return _categoryRepository.Delete(category);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Category FindCategory(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _categoryRepository.GetAll();
        }

        public string UpdateCategory(Category category)
        {
            try
            {
                category.Status = Entity.Enum.Status.Updated;
                return _categoryRepository.Update(category);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
