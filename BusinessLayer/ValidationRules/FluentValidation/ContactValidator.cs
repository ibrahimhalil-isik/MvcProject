using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage(" Kullanıcı Adı boş olmamalı ");
            RuleFor(c => c.UserName).MinimumLength(3).WithMessage(" Kullanıcı adı en az 3 karakter olmalı");
            RuleFor(c => c.UserName).MaximumLength(50).WithMessage(" Kategori adı en fazla 50 karakter olmalı");

            RuleFor(c => c.UserMail).NotEmpty().WithMessage(" Mail Adresi boş olmamalı");

            RuleFor(c => c.Subject).NotEmpty().WithMessage(" Konu Adı boş olmamalı");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage(" En az 3 karakter girişi yapınız. ");
        }
    }
}
