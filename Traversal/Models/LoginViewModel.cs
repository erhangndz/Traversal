using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class LoginViewModel
	{
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Girin")]
        public string Username { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
		public string Password { get; set; }
    }
}
