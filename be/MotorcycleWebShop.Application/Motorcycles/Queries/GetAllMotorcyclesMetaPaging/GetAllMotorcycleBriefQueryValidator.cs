using FluentValidation;
using MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcycles;

namespace MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcyclesMetaPaging
{
    public class GetAllMotorcycleBriefQueryValidator : AbstractValidator<GetAllMotorcycleBriefQuery>
    {
        public GetAllMotorcycleBriefQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotNull().WithMessage("The PageNumber should not be null")
                .LessThan(0).WithMessage($"The value of PageNumber must be greater than 0");

            RuleFor(x => x.PageSize)
                .NotNull().NotNull().WithMessage("The PageSize should not be null")
                .GreaterThan(10).WithMessage("The value of PageSize must be lower than 10");
        }
    }
}
