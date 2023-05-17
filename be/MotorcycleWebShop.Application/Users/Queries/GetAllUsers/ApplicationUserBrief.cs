using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Application.Users.Queries.GetAllUsers
{
    public class ApplicationUserBrief : IMapFrom<ApplicationUser>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, ApplicationUserBrief>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.FullName))
                .ForMember(s => s.Avatar, opt => opt.MapFrom(d => d.Avatar));
        }
    }
}
