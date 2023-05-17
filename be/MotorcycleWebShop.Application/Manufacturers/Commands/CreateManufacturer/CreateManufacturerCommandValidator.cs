using FluentValidation;

namespace MotorcycleWebShop.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
    {
        public CreateManufacturerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name must not be empty")
                .MaximumLength(150).WithMessage("The name length must lower than 150");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("The Description length must lower than 250");

            RuleFor(x => x.From)
                .NotEmpty().WithMessage("The Country must not be empty")
                .MaximumLength(150).WithMessage("The Country length must lower than 150");
        }
    }
}
