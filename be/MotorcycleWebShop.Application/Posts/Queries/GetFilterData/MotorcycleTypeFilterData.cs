using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Posts.Queries.GetFilterData
{
    public class MotorcycleTypeFilterData : IMapFrom<MotorcycleType>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
