using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Motorcycles.Commands.DeleteMotorcycle
{
    public record DeleteMotorcycleCommand(int id) : IRequest;

    public class DeleteMotorcycleCommandHandler : IRequestHandler<DeleteMotorcycleCommand>
    {
        private readonly IApplicationDbContext _db;

        public DeleteMotorcycleCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Motorcycles
                .FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Motorcycle), request.id);
            }

            _db.Motorcycles.Remove(entity);

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
