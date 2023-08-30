using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz.")]
		[Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
		public string ConfirmPassword { get; set; }
    }
}
