using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcycles
{
    public class MotorcycleBriefItemDto : IMapFrom<Motorcycle>
    {
        public int Id { get; set; }
        public string MotorcycleName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Motorcycle, MotorcycleBriefItemDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.MotorcycleName, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.ManufacturerId, opt => opt.MapFrom(s => s.ManufacturerId))
                //.ForMember(des => des.ManufacturerName, opt => opt.MapFrom(s => s.Manufacturer.Name))
                .ForMember(des => des.ImagePath, opt => opt.MapFrom(s => s.ImagePath));
        }
    }
}
