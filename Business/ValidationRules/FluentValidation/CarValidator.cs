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
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);
            RuleFor(c => c.BrandName).Must(StartWithN).WithMessage("Araba adları N harfi ile başlamalı");
        }

        private bool StartWithN(string arg)
        {
            return arg.StartsWith("N");
        }
    }
}
