using System.ComponentModel.DataAnnotations;

namespace NetECommerce.MVC.Models.ViewModels
{
    public class RegisterVM
    {
        //Username
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        [Display(Name ="Kullanıcı adı")]
        public string Username { get; set; }

        //Email
        [Required(ErrorMessage ="email boş geçilemez!")]
        [EmailAddress(ErrorMessage ="email adresi formatında olmalı")]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        //Password
        [Required(ErrorMessage = "şifre boş geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        //ConfirmPassword

        [Required(ErrorMessage = "şifre (tekrar) boş geçilemez!")]
        [Compare("Password",ErrorMessage ="şifreler uyuşmuyor!")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
