using FluentValidation;
using StitchTime.Core.Dto;
using System;

namespace StitchTime.Core.Validators
{
    public class ReportValidator : AbstractValidator<ReportDto>
    {
        double maxTime = 8;
        public ReportValidator()
        {
            RuleFor(x => x.Time)
                .LessThanOrEqualTo(maxTime)
                .WithMessage("Bad report info");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Empty description");
            RuleFor(x => x.StartDate.DayOfWeek)
                .NotEqual(DayOfWeek.Saturday)
                .NotEqual(DayOfWeek.Sunday)
                .WithMessage("Don't work on weekend :)");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start date must stand before end date.");
        }
    }
}
