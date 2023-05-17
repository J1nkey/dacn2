using FluentValidation;

namespace MotorcycleWebShop.Application.Identity.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty")
                .MaximumLength(150).WithMessage($"{nameof(RegisterUserCommand.Email)} length must be lower than 150")
                .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Format of email is invalid");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Email must not be empty")
                .MaximumLength(250).WithMessage("FirstName length must be lower than 250");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Email must not be empty")
                .MaximumLength(250).WithMessage("FirstName length must be lower than 250");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName must not be empty")
                .MaximumLength(150).WithMessage("UserName length must be lower than 150");
        }
    }
}
