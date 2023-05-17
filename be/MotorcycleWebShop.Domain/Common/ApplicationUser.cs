using Microsoft.AspNetCore.Identity;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Domain.Common
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
        public string FullName => FirstName + LastName;
        public Provider Provider { get; set; }
        public virtual ICollection<Message> MessagesFromUsers { get; set; }
        public virtual ICollection<Message> MessagesToUsers { get; set; }
    }
}
