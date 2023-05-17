using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Slides.Queries.GetSlides
{
    public class BaseSlideDto : IMapFrom<Slide>
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Slide, BaseSlideDto>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.ImagePath, opt => opt.MapFrom(d => d.ImagePath))
                .ForMember(s => s.SortOrder, opt => opt.MapFrom(d => d.SortOrder));
        }
    }
}
