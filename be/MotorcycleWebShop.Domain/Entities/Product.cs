using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Product : AuditableEntity, IEntityActivable
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double? Torque { get; set; }
        public double? HorsePower { get; set; }
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public bool IsActive { get; set; }
    }
}
