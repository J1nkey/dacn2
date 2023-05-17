using FluentValidation;

namespace MotorcycleWebShop.Application.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
    {
        public UpdateManufacturerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name must not be empty")
                .MaximumLength(150).WithMessage("The Name length must lower than 150");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("The Description must not be empty")
                .MaximumLength(250).WithMessage($"The {nameof(UpdateManufacturerCommand.Description)} lenght must lower than 250");
        }
    }
}
