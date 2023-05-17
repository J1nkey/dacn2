using FluentValidation;

namespace MotorcycleWebShop.Application.Motorcycles.Commands.UpdateMotorcycleDetail
{
    public class UpdateMotorcycleDetailCommandValidator : AbstractValidator<UpdateMotorcycleDetailCommand>
    {
        public UpdateMotorcycleDetailCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.Description).MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.Torque)
                .NotEmpty();
            RuleFor(x => x.CubicCentimeters)
                .NotEmpty();
            RuleFor(x => x.HorsePower)
                .NotEmpty();
        }
    }
}
