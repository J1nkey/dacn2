using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Manufacturers.Commands.DeleteManufacturerById
{
    public record DeleteManufacturerByIdCommand(int Id) : IRequest;

    public class DeleteManufacturerByIdCommandHandler : IRequestHandler<DeleteManufacturerByIdCommand>
    {
        private readonly IApplicationDbContext _db;

        public DeleteManufacturerByIdCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(DeleteManufacturerByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Manufacturers
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Manufacturer), request.Id);
            }

            _db.Manufacturers.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
