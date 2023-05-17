using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Posts.Queries.GetFilterData
{
    public class ManufacturerFilterData : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
