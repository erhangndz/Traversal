using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SendMessageValidator:AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Yazın.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen Konuyu Yazın.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter Yazın.");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter Yazın.");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Lütfen Mesajınızı Yazın.");
            RuleFor(x => x.MessageBody).MinimumLength(10).WithMessage("Lütfen en az 10 karakter Yazın.");
            RuleFor(x => x.MessageBody).MaximumLength(250).WithMessage("Lütfen en fazla 250 karakter Yazın.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen Mailinizi Yazın.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Yazın.");
        }
    }
}
