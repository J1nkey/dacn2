using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Identity.Login
{
    public class LoginResponseDto : TokenResult
    {
        public string Message { get; set; }
    }
}
