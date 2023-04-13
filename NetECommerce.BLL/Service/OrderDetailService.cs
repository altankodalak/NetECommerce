using NetECommerce.BLL.Abstract;
using NetECommerce.BLL.AbstractService;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepository<OrderDetail> orderDetailRepository;

        public OrderDetailService(IRepository<OrderDetail> orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }
        public string CreateOrderDetails(OrderDetail Order)
        {
            try
            {
                return orderDetailRepository.Create(Order);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailRepository.GetAll();
        }
    }
}
