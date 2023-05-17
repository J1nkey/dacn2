using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class NavigationBarItem : EntityId
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsParentItem { get; set; }
        public int? ParentId { get; set; }
    }
}
