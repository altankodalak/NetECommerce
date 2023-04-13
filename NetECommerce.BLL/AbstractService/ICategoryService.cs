using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.AbstractService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategorys();

        string CreateCategory(Category Category);

        string DeleteCategory(Category Category);

        string UpdateCategory(Category Category);

        Category FindCategory(int id);
    }
}
