using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Manufacturers.Commands.CreateManufacturer
{
    public record CreateManufacturerCommand : IRequest<int>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string From { get; init; }
    }

    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateManufacturerCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Manufacturer
            {
                Name = request.Name,
                Description = request.Description,
                From = request.From,
                ImagePath = null
            };

            _db.Manufacturers.Add(entity);

            await _db.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
