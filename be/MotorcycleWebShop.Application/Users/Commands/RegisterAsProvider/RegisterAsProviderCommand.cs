using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Users.Commands.RegisterAsProvider
{
    public record RegisterAsProviderCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string ProviderName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RegisterAsProviderCommandHandler : IRequestHandler<RegisterAsProviderCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public RegisterAsProviderCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(RegisterAsProviderCommand request, CancellationToken cancellationToken)
        {
            // We must checked is that user still is a provider now
            var user = await _db.Users.FindAsync(new object[] { request.UserId });

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            }

            var isUserInProvider = _db.Providers.Any(x => x.ApplicationUserId == request.UserId);

            if (isUserInProvider)
            {
                throw new InvalidRegisterUserAsProviderException($"{request.UserId} still is a Provider");
            }

            var provider = new Provider
            {
                Name = request.ProviderName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                ApplicationUser = user,
            };

            _db.Providers.Add(provider);
            await _db.SaveChangesAsync(cancellationToken);

            return provider.Id;
        }
    }
}
