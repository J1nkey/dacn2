using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Navigation.Queries.GetHierarchyNavbarItems
{
    public class BaseNavbarItem : IMapFrom<NavigationBarItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NavigationBarItem, BaseNavbarItem>()
                .ForMember(s => s.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.Url, opt => opt.MapFrom(s => s.Url));
        }
    }
}
