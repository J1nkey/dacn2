using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.MotorcycleTypes.Queries.GetMotorcycleTypes
{
    public record GetMotorcycleTypesQuery : IRequest<GetMotorcycleTypesQueryResponse>
    {
    }

    public class GetMotorcycleTypesQueryHandler : IRequestHandler<GetMotorcycleTypesQuery, GetMotorcycleTypesQueryResponse>
    {
        private readonly IApplicationDbContext _db;

        public GetMotorcycleTypesQueryHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GetMotorcycleTypesQueryResponse> Handle(GetMotorcycleTypesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetMotorcycleTypesQueryResponse();

            var types = await _db.MotorcycleTypes
                .AsNoTracking()
                .ToListAsync();
            response.Items = types;

            return response;
        }
    }

    public class GetMotorcycleTypesQueryResponse
    {
        public ICollection<MotorcycleType> Items { get; set; }
    }
}
