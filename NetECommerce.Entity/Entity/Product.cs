using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetECommerce.Entity.Entity
{
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
