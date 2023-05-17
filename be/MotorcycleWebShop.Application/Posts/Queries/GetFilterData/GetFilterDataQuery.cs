using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Posts.Queries.GetFilterData
{
    public record GetFilterDataQuery : IRequest<GetFilterDataQueryResponse>
    {
    }

    public class GetFilterDataQueryHandler : IRequestHandler<GetFilterDataQuery, GetFilterDataQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetFilterDataQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetFilterDataQueryResponse> Handle(GetFilterDataQuery request, CancellationToken cancellationToken)
        {
            var response = new GetFilterDataQueryResponse();

            response.Manufacturers = await _db.Manufacturers
                .AsNoTracking()
                .ProjectTo<ManufacturerFilterData>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.MotorcycleTypes = await _db.MotorcycleTypes
                .AsNoTracking()
                .ProjectTo<MotorcycleTypeFilterData>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return response;
        }
    }

    public class GetFilterDataQueryResponse
    {
        public ICollection<ManufacturerFilterData> Manufacturers { get; set; }
        public ICollection<MotorcycleTypeFilterData> MotorcycleTypes { get; set; }
        public SortTypeFilterData SortTypes { get; set; }
    }
}
