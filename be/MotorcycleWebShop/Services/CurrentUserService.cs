using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Models;
using System.Security.Claims;

namespace MotorcycleWebShop.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _context;

        public CurrentUserService(
            IHttpContextAccessor context
            )
        {
            _context = context;
        }

        public int UserId => int.Parse(_context.HttpContext?.User?.FindFirstValue(IdentityClaimTypes.Uid));
    }
}
