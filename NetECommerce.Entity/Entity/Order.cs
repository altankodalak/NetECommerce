using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Entity.Entity
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderDetails=new List<OrderDetail>();
        }
        public AppUser User { get; set; }
        public bool Shipped { get; set; }
        public int? ShipperId { get; set; }
        public string Ordernumber { get; set; }
        public virtual Shipper Shipper { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
