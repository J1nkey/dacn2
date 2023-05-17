using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Manufacturers.Queries.GetAllManufacturersPaging
{
    public class ManufacturerItemDto : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, ManufacturerItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.ImagePath, opt => opt.MapFrom(s => s.ImagePath))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
