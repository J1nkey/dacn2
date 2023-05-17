using FluentValidation;

namespace MotorcycleWebShop.Application.Identity.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("The UserName must not be empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The Password must not be empty")
                .MaximumLength(32).WithMessage("The Password length must lower than 32 characters");
        }
    }
}
