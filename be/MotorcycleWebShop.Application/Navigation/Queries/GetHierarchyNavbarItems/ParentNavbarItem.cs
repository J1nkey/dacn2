using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Application.Navigation.Queries.GetHierarchyNavbarItems
{
    public class ParentNavbarItem : BaseNavbarItem
    {
        // For storing sub items to display on the screen
        public ICollection<BaseNavbarItem> SubItems { get; set; }
    }
}
