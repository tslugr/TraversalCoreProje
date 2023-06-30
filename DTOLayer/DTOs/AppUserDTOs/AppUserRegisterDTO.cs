using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
