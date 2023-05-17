using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Posts.Queries.GetBriefPost
{
    public class BriefPostDto : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double KilometersConsumption { get; set; }
        public string ProviderName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, BriefPostDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.KilometersConsumption, opt => opt.MapFrom(x => x.KilometersConsumption));
        }
    }
}
