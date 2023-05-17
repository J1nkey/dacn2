using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class MotorcycleType : EntityId
    {
        public string TypeName { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
