using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Manufacturer : EntityId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? From { get; set; } = "";
        public string ImagePath { get; set; }
        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
