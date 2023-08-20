using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AddAnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlığı yazınız.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter yazınız.");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter yazınız.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen Duyuru içeriğini yazınız.");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lütfen en az 20 karakter yazınız.");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter yazınız.");
        }
    }
}
