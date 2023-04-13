using NetECommerce.BLL.Abstract;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public string CreateOrder(Order Order)
        {
            try
            {
                return orderRepository.Create(Order);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepository.GetAll();
        }
    }
}
