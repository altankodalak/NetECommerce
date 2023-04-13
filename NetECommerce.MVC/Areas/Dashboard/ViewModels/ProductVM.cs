using NetECommerce.Entity.Entity;

namespace NetECommerce.MVC.Areas.Dashboard.ViewModels
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Category Category { get; set; }
    }
}
