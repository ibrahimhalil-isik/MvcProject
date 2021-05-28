using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage(" Kategori adı boş olmamalı ");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage(" Kategori adı en az 3 karakter olmalı");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage(" Kategori adı en fazla 20 karakter olmalı");

            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage(" Açıklama boş olmamalı");
            RuleFor(c => c.CategoryDescription).MinimumLength(20).WithMessage(" Açıklama en az 20 karakter olmalı");
            RuleFor(c => c.CategoryDescription).MaximumLength(200).WithMessage(" Açıklama en fazla 200 karakter olmalı");
        }
    }
}