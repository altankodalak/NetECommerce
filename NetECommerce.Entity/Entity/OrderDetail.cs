using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Entity.Entity
{
    public class OrderDetail:BaseEntity
    {


        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        
        public Order Order { get; set; }

        public decimal? UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
