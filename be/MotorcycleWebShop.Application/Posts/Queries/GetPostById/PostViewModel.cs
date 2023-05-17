using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Posts.Queries.GetPostById
{
    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double KilometersConsumption { get; set; }
        public double CubicCentimeters { get; set; }
        public double HorsePower { get; set; }
        public double Torque { get; set; }
        public int MotorcycleId { get; set; }
        public int ManufacturerId { get; set; } // For get related post
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostViewModel>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.Title, opt => opt.MapFrom(d => d.Title))
                .ForMember(s => s.Details, opt => opt.MapFrom(d => d.Details))
                .ForMember(s => s.KilometersConsumption, opt => opt.MapFrom(d => d.KilometersConsumption))
                .ForMember(s => s.CubicCentimeters, opt => opt.MapFrom(d => d.CubicCentimeters))
                .ForMember(s => s.HorsePower, opt => opt.MapFrom(d => d.HorsePower))
                .ForMember(s => s.Torque, opt => opt.MapFrom(d => d.Torque))
                .ForMember(s => s.MotorcycleId, opt => opt.MapFrom(d => d.MotorcycleId));
        }
    }
}
