using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Motorcycles.Commands.UpdateMotorcycleDetail
{
    public record UpdateMotorcycleDetailCommand : IRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public double Torque { get; init; }
        public double HorsePower { get; init; }
        public double CubicCentimeters { get; init; }
    }

    public class UpdateMotorcycleDetailCommandHandler : IRequestHandler<UpdateMotorcycleDetailCommand>
    {
        private readonly IApplicationDbContext _db;

        public UpdateMotorcycleDetailCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(UpdateMotorcycleDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Motorcycles
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Motorcycle), request.Id);
            }

            entity.Name = request.Name;
            entity.CubicCentimeters = request.CubicCentimeters;
            entity.Torque = request.Torque;
            entity.HorsePower = request.HorsePower;
            entity.Description = request.Description;

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
