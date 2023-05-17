using MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcycles;

namespace MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcyclesMeta
{
    public class MotorcycleMetaListVm
    {
        public IReadOnlyCollection<MotorcycleBriefItemDto> Lists { get; init; } = Array.Empty<MotorcycleBriefItemDto>();
    }
}
