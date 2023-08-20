using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDto
    {
        
        public string NameSurname { get; set; }

       
        public string Username { get; set; }

       
        public string PhoneNumber { get; set; }

       
        public string Mail { get; set; }

       
        public string Password { get; set; }

      
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
