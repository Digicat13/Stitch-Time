using FluentValidation;
using StitchTime.Core.Dto;

namespace StitchTime.Core.Validators
{
    public class ReportValidator : AbstractValidator<ReportDto>
    {
        double maxTime = 8;
        public ReportValidator()
        {
            RuleFor(x => x.Time)
                .NotEmpty()
                .LessThanOrEqualTo(maxTime)
                .WithMessage("Bad report info");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Empty description");
        }
    }
}
