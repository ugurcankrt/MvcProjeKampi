using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı kısmını boş geçemezsiniz.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu en fazla 100 karakterden oluşmalıdır.");

        }
    }
}
