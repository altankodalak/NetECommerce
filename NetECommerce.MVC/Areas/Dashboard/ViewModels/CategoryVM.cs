using System.ComponentModel.DataAnnotations;

namespace NetECommerce.MVC.Areas.Dashboard.ViewModels
{
    public class CategoryVM
    {
        [Required(ErrorMessage ="Kategori adı boş geçilemez!")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
