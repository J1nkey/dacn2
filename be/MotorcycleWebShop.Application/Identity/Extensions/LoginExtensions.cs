using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MotorcycleWebShop.Application.Common.Models;
using MotorcycleWebShop.Application.Options.JwtOptions;
using MotorcycleWebShop.Domain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotorcycleWebShop.Application.Identity.Extensions
{
    public static class LoginExtensions
    {
        public async static Task SetLoginSuccessResult(ApplicationUser user, UserManager<ApplicationUser> userManager, TokenResult result, JwtOptions options)
        {
            var roles = await userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(IdentityClaimTypes.Uid, user.Id.ToString()),
                new Claim(IdentityClaimTypes.FullName, user.FullName),
                new Claim(IdentityClaimTypes.Email, user.Email),
                new Claim(IdentityClaimTypes.Roles, string.Join(",", roles))
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = options.ValidAudience,
                Issuer = options.ValidIssuer,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecurityKey)),
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddMinutes(5),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            result.IsSuccess = true;
            result.TokenAuth = jwtToken;
        }
    }
}
