using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Posts.Queries.GetBriefPostByManufacturerIdPaging
{
    public record GetBriefPostByManufacturerIdPagingQuery : IRequest<GetBriefPostByManufacturerIdPagingQueryResponse>
    {
        public int ManufacturerId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetBriefPostByManufacturerIdPagingQueryHandler
        : IRequestHandler<GetBriefPostByManufacturerIdPagingQuery, GetBriefPostByManufacturerIdPagingQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetBriefPostByManufacturerIdPagingQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetBriefPostByManufacturerIdPagingQueryResponse> Handle(GetBriefPostByManufacturerIdPagingQuery request, CancellationToken cancellationToken)
        {
            var posts = await _db.Posts.AsNoTracking()
                .Include(t => t.Motorcycle)
                .Where(x => x.Motorcycle.ManufacturerId == request.ManufacturerId)
                .OrderBy(x => x.CreatedAt)
                .ProjectTo<BriefPostDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            var response = new GetBriefPostByManufacturerIdPagingQueryResponse(request.ManufacturerId, posts);

            return response;
        }
    }

    public class GetBriefPostByManufacturerIdPagingQueryResponse 
    {
        public int ManufacturerId { get; set; }
        public PaginatedList<BriefPostDto> Items { get; set; }

        public GetBriefPostByManufacturerIdPagingQueryResponse()
        {
        }

        public GetBriefPostByManufacturerIdPagingQueryResponse(int manufacturerId,
            PaginatedList<BriefPostDto> items)
        {
            ManufacturerId = manufacturerId;
            Items = items;
        }
    }
}
