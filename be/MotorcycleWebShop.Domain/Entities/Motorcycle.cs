using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Motorcycle : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CubicCentimeters { get; set; }
        public double Torque { get; set; }
        public double HorsePower { get; set; }
        public string ImagePath { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get;set; }
        public int MotorcycleTypeId { get; set; }
        public MotorcycleType MotorcycleType { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
