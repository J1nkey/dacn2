using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Manufacturers.Queries.GetAllManufacturersPaging
{
    public class GetAllManufacturersPagingQuery : IRequest<PaginatedList<ManufacturerItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetAllManufacturersPagingQuery()
        {
        }

        public GetAllManufacturersPagingQuery(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllManufacturersPagingQueryHandler : IRequestHandler<GetAllManufacturersPagingQuery, PaginatedList<ManufacturerItemDto>>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetAllManufacturersPagingQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<PaginatedList<ManufacturerItemDto>> Handle(GetAllManufacturersPagingQuery request, CancellationToken cancellationToken)
        {
            var response = await _db.Manufacturers
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<ManufacturerItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return response;

        }
    }
}
