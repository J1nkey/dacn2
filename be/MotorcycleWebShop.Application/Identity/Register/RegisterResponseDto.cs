using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Identity.Register
{
    public class RegisterResponseDto : TokenResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
