using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Manufacturers.Commands.UpdateManufacturer
{
    public record UpdateManufacturerCommand : IRequest
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }

    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand>
    {
        private readonly IApplicationDbContext _db;

        public UpdateManufacturerCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Manufacturers
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Manufacturer), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
