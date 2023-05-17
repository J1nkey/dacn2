using FluentValidation;

namespace MotorcycleWebShop.Application.Motorcycles.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>
    {
        public CreateMotorcycleCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Description).MaximumLength(200).NotEmpty();
            RuleFor(v => v.CubicCentimeters).NotEmpty();
            RuleFor(v => v.Torque).NotEmpty();
            RuleFor(v => v.HorsePower).NotEmpty();
        }
    }
}
