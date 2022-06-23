using FluentValidation;

namespace SmartMedChallenge.Domain.Models.Validations
{
    public class MedicationValidation : AbstractValidator<Medication>
    {
        public MedicationValidation()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be null or empty.")
                .MaximumLength(100).WithMessage("{PropertyName} must contain a maximum of {PropertyValue} characters.");

            RuleFor(m => m.Quantity)
                .NotEmpty().WithMessage("{PropertyName} can not be null or empty.")
                .GreaterThan(0).WithMessage("{PropertyName} has to be greater than 0.");
        }
    }
}
