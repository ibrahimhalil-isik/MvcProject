using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.Subject).NotEmpty().WithMessage(" Konu boş olmamalı.");
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage(" Alıcı adresi boş olmamalı.");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage(" Mesaj boş olmamalı.");

            RuleFor(m => m.Subject).MinimumLength(3).WithMessage(" Konu en az 3 karakter olmalı");
            RuleFor(m => m.Subject).MaximumLength(50).WithMessage(" Konu en fazla 50 karakter olmalı");

            RuleFor(m => m.MessageContent).MinimumLength(10).WithMessage(" Mesaj içeriği en az 10 karakter olmalı");
        }
    }
}
