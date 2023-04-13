using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Entity.Entity
{
    public class Supplier:BaseEntity
    {
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public List<Product> Products { get; set; }
    }
}
