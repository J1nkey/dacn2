using Microsoft.AspNetCore.Identity;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(int userId);
        Task<(Result Result, int userId)> CreateUserAsync(string userName, string email, string password);

        Task<(Result Result, int userId)> CreateUserAsync(string userName, string email, string password, string firstName, string lastName, string dob, string IdentificationNumber);
        Task<Result> DeleteUserAsync(int userId);
    }
}
