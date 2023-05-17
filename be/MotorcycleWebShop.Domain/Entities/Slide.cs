using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Slide : AuditableEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; }
    }
}
