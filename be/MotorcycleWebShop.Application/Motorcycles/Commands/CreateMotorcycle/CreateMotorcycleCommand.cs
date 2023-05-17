using MediatR;
using Microsoft.AspNetCore.Http;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Motorcycles.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CubicCentimeters { get; set; }
        public double Torque { get; set; }
        public double HorsePower { get; set; }
        public IFormFile? ImagePath { get; set; }
        public int ManufacturerId { get; set; }
        public int MotorcycleTypeId { get; set; }
    }

    public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateMotorcycleCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Motorcycle
            {
                Name = request.Name,
                Description = request.Description,
                HorsePower = request.HorsePower,
                Torque = request.Torque,
                CubicCentimeters = request.CubicCentimeters,
                ManufacturerId = request.ManufacturerId,
                MotorcycleTypeId = request.MotorcycleTypeId
            };

            _db.Motorcycles.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
