using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş bırakamazsınız.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik bir açıklama bilgisi yazın.");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama bilgisi çok uzun.");
        }
    }
}
