using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(h => h.HeadingName).NotEmpty().WithMessage(" Başlık Adı kısmı boş olmamalı ");
            RuleFor(h => h.HeadingName).MinimumLength(3).WithMessage(" Başlık Adı en az 3 karakter olmalı");
        }
    }
}
