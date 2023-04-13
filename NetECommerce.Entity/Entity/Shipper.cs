using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Entity.Entity
{
    public class Shipper:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
