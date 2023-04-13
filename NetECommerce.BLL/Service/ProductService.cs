using NetECommerce.BLL.Abstract;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetECommerce.BLL.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public string CreateProduct(Product product)
        {
            try
            {
               return _productRepository.Create(product);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string DeleteProduct(Product product)
        {
            try
            {
                return _productRepository.Delete(product);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public string UpdateProduct(Product product)
        {
            try
            {
                return _productRepository.Update(product);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
