using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NetECommerce.MVC.Models.ViewModels
{
    public class LoginVM
    {
        //Username
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı adı")]
        public string Username { get; set; }

        //Password
        [Required(ErrorMessage = "şifre boş geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
