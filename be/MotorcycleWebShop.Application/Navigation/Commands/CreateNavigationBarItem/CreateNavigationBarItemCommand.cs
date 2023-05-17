using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Navigation.Commands.CreateNavigationBarItem
{
    public record CreateNavigationBarItemCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsParentItem { get; set; }
        public int? ParentId { get; set; }
    }

    public class CreateNavigationBarItemCommandHandler : IRequestHandler<CreateNavigationBarItemCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateNavigationBarItemCommandHandler(
            IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateNavigationBarItemCommand request, CancellationToken cancellationToken)
        {
            var newNavbarItem = new NavigationBarItem
            {
                Name = request.Name,
                IsParentItem = request.IsParentItem,
                Url = request.Url,
                ParentId = request.IsParentItem ? null : request.ParentId
            };

            _db.NavigationBarItems.Add(newNavbarItem);
            await _db.SaveChangesAsync(cancellationToken);

            return newNavbarItem.Id;
        }
    }
}
