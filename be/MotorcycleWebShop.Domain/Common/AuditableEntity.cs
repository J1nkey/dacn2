namespace MotorcycleWebShop.Domain.Common
{
    public class AuditableEntity : EntityId
    {
        public int CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
