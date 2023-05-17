using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Application.Navigation.Queries.GetHierarchyNavbarItems
{
    public record GetHierarchyNavbarItemsQuery : IRequest<GetHierarchyNavbarItemsQueryResponse>
    {
    }

    public class GetHierarchyNavbarItemsQueryHandler : IRequestHandler<GetHierarchyNavbarItemsQuery, GetHierarchyNavbarItemsQueryResponse>
    {
        private readonly IApplicationDbContext _db;

        public GetHierarchyNavbarItemsQueryHandler(
            IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GetHierarchyNavbarItemsQueryResponse> Handle(GetHierarchyNavbarItemsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetHierarchyNavbarItemsQueryResponse();

            // Get parent navigation item
            try
            {
                var navbarItems = await _db.NavigationBarItems
                    .Select(x => new NavigationBarItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Url = x.Url,
                        ParentId = x.ParentId
                    })
                    .ToListAsync();

                var groupedItems = navbarItems.GroupBy(x => x.ParentId);

                if (groupedItems.Count() > 0)
                {
                    response.Items = new List<ParentNavbarItem>();
                    foreach (var item in groupedItems)
                    {
                        // If Key is null, that means it is navigation parent items
                        if (item.Key == null || item.Key == 0)
                        {
                            foreach (var navbarItem in item)
                            {
                                Debugger.Log(1, nameof(GetHierarchyNavbarItemsQuery), $"{navbarItem.Id} - {navbarItem.Name}");
                                response.Items.Add(new ParentNavbarItem
                                {
                                    Id = navbarItem.Id,
                                    Name = navbarItem.Name,
                                    Url = navbarItem.Url
                                });
                            }
                        }
                        else
                        {
                            var parentItem = response.Items.Where(x => x.Id == item.Key).First();
                            parentItem.SubItems = new List<BaseNavbarItem>();
                            foreach (var navbarItem in item)
                            {
                                parentItem.SubItems.Add(new BaseNavbarItem
                                {
                                    Id = navbarItem.Id,
                                    Name = navbarItem.Name,
                                    Url = navbarItem.Url
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1, nameof(GetHierarchyNavbarItemsQueryHandler), ex.Message);
            }


            //var children = await _db.NavigationBarItems.Where(x => x.ParentId != null)
            //    .OrderBy(x => x.ParentId)
            //    .ToListAsync();


            return response;
        }
    }

    public class GetHierarchyNavbarItemsQueryResponse
    {
        public ICollection<ParentNavbarItem> Items { get; set; }
    }
}
