using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandName).NotEmpty();
            RuleFor(c => c.BrandName).MinimumLength(2);
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Açıklama en az 2 karakter olmalıdır");
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c => c.BrandId == 1);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(p => p.Description).Must(StartWithN).When(p => p.Description != null).WithMessage("Açıklama 'N' karakteri ile başlamalı");
        }

        private bool StartWithN(string arg)
        {
            return arg.StartsWith("N");
        }
    }
}
