using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.AbstractService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        string CreateProduct(Product product);

        string DeleteProduct(Product product);

        string UpdateProduct(Product product);

        Product GetById(int id);

       
    }
}
