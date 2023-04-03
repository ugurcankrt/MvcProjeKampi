using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar  adı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakterden oluşmalıdır.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar  soyadı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakterden oluşmalıdır.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanını boş geçemezsiniz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifresi boş geçemezsiniz.");


            // RuleFor(x => x.WriterAbout).Must(ContainsIsA).WithMessage("Hakkımda kısmı a karakteri içermek zorundadır.");

        }

        public bool ContainsIsA(string p)
        {
            bool value = p.Contains("a");
            return value;
        }
    }
}
