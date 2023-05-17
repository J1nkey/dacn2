using Microsoft.AspNetCore.Identity;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Succeeded()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
