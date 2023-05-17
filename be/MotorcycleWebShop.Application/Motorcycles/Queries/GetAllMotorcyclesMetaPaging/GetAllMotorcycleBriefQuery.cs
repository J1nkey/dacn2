using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Application.Common.Models;
using MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcyclesMeta;

namespace MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcycles
{
    public record GetAllMotorcycleBriefQuery : IRequest<PaginatedList<MotorcycleBriefItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetAllMotorcycleBriefQuery()
        {
        }

        public GetAllMotorcycleBriefQuery(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllMotorcycleBriefQueryHandler : IRequestHandler<GetAllMotorcycleBriefQuery, PaginatedList<MotorcycleBriefItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMotorcycleBriefQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<MotorcycleBriefItemDto>> Handle(GetAllMotorcycleBriefQuery request, CancellationToken cancellationToken)
        {
            return await _context.Motorcycles
                    .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .ProjectTo<MotorcycleBriefItemDto>(_mapper.ConfigurationProvider)
                    .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
