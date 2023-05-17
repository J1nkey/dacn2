using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public double KilometersConsumption { get; set; }
        public double CubicCentimeters { get; set; }
        public double HorsePower { get; set; }
        public double Torque { get; set; }
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
