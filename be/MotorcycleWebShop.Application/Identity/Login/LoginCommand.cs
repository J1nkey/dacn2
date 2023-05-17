using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Identity.Extensions;
using MotorcycleWebShop.Application.Options.JwtOptions;
using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Application.Identity.Login
{
    public record LoginCommand : IRequest<LoginResponseDto>
    {
        public string UserName { get; init;}
        public string Password { get; init; }
        public bool RememberMe { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public LoginCommandHandler(IApplicationDbContext db,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResponseDto response = new LoginResponseDto();
            var user = _db.Users.FirstOrDefault(x => x.UserName == request.UserName);

            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = $"The UserName {request.UserName} is not existed";

                return response;
            }

            var signinResponse = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            if (signinResponse.Succeeded)
            {
                await LoginExtensions.SetLoginSuccessResult(user, _userManager, response, _jwtOptions);
            }
            else if (signinResponse.IsLockedOut)
            {
                response.Message = $"User {request.UserName} is locked out";
                response.IsSuccess = false;
            }
            else
            {
                response.Message = $"{nameof(ApplicationUser)} (the login process of {request.UserName}) failed";
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
