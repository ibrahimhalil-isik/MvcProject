using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage(" Yazar adı boş olmamalı ");
            RuleFor(w => w.WriterSurName).NotEmpty().WithMessage(" Yazar soyadı boş olmamalı ");
            RuleFor(w => w.WriterAbout).NotEmpty().WithMessage(" Yazar hakkında kısmı boş olmamalı ");
            RuleFor(w => w.WriterName).MinimumLength(3).WithMessage(" Yazar adı en az 3 karakter olmalı");
            RuleFor(w => w.WriterName).MaximumLength(50).WithMessage(" Yazar adı en fazla 50 karakter olmalı");
            RuleFor(w => w.WriterSurName).MaximumLength(50).WithMessage(" Yazar soyadı en fazla 50 karakter olmalı");

            RuleFor(w => w.WriterName).Must(IsThereAnyA).WithMessage(" Yazar adı içerisinde 'A' harfi olmalı ");
        }

        private bool IsThereAnyA(string arg)
        {
            bool value = false;
            var result = arg.ToLower().IndexOf("a");

            if (result>=0)
            {
                value = true;
            }
            else
            {
                value = false;
            }

            return value;
        }        
    }
}
