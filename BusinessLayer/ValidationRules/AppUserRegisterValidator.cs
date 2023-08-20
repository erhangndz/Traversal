using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adını Boş Bırakamazsınız.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad alanını Boş Bırakamazsınız.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreyi Boş Bırakamazsınız.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifreyi lütfen tekrar giriniz.");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Şifreler birbiriyle uyuşmuyor.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanını Boş Bırakamazsınız.");
        }
    }
}
