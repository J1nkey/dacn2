using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Message : AuditableEntity
    {
        public string MessageValue { get; set; }
        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public int ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}
