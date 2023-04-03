using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Usermail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(3).WithMessage("Konu en fazla 50 karakterden oluşmalıdır.");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Mesaj en az 10 karakterden oluşmalıdır.");

        }
    }
}
