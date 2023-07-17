using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz.")]
        public string NameSurname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen Telefon Numarası Giriniz.")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen Email Adresi Giriniz.")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
		[Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
		public string ConfirmPassword { get; set; }

	}
}
