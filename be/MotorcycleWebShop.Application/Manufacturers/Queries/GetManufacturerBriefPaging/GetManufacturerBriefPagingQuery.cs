using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Manufacturers.Queries.GetManufacturerBriefPaging
{
    public record GetManufacturerBriefPagingQuery : IRequest<PaginatedList<ManufacturerBriefDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetManufacturerBriefPagingQueryHandler : IRequestHandler<GetManufacturerBriefPagingQuery, PaginatedList<ManufacturerBriefDto>>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetManufacturerBriefPagingQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ManufacturerBriefDto>> Handle(GetManufacturerBriefPagingQuery request, CancellationToken cancellationToken)
        {
            var manufacturerBriefs = await _db.Manufacturers
                .AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<ManufacturerBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return manufacturerBriefs;
        }
    }
}
