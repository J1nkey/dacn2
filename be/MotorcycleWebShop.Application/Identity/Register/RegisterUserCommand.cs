using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Identity.Extensions;
using MotorcycleWebShop.Application.Options.JwtOptions;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Identity.Register
{
    public record RegisterUserCommand : IRequest<RegisterResponseDto>
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string IdentificationNumber { get; init; }
        public DateTime Dob { get; init; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterResponseDto>
    {
        private readonly IApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public RegisterUserCommandHandler(IApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _db = db;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<RegisterResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpper(),
                IdentificationNumber = request.IdentificationNumber,
                Dob = request.Dob,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var isUserExisted = _db.Users.Any(x => x.Email == request.Email || x.UserName == request.UserName);

            if (isUserExisted == true)
            {
                throw new UserExistedException(nameof(ApplicationUser), $"{request.Email} or {request.UserName}");
            }

            PasswordHasher<ApplicationUser> hashser = new PasswordHasher<ApplicationUser>();
            entity.PasswordHash = hashser.HashPassword(null, request.Password);

            _db.Users.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);

            RegisterResponseDto response = new RegisterResponseDto();
            await LoginExtensions.SetLoginSuccessResult(entity, _userManager, response, _jwtOptions);

            response.UserId = entity.Id;
            response.FullName = entity.FullName;

            return response;
        }
    }
}
