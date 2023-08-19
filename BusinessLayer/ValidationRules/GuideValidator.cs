using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Açıklama Giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Görsel Giriniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha kısa bir İsim giriniz.");
            RuleFor(x => x.Name).MinimumLength(6).WithMessage("Lütfen en az 6 karakter uzunluğunda bir İsim giriniz.");

        }
    }
}
