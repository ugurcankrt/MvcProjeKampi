using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek adı boş geçilemez.");
            RuleFor(x => x.SkillName).MinimumLength(2).WithMessage("Yetenek adı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.SkillName).MaximumLength(30).WithMessage("Yetenek adı en fazla 30 karakterden oluşmalıdır.");
            RuleFor(x => x.SkillValue).NotEmpty().WithMessage("Yetenek oranı boş geçilemez.");
            RuleFor(x => x.SkillValue).LessThanOrEqualTo(100).WithMessage("Yetenek oranı en fazla 100 olabilir.");
            RuleFor(x => x.SkillValue).GreaterThan(0).WithMessage("Yetenek oranı en az 0 olabilir.");
        }
    }
}
