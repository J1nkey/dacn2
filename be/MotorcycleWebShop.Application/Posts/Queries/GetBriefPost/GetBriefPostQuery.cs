using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Application.Common.Models;

namespace MotorcycleWebShop.Application.Posts.Queries.GetBriefPost
{
    public record GetBriefPostQuery : IRequest<PaginatedList<BriefPostDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetBriefPostQueryHandler : IRequestHandler<GetBriefPostQuery, PaginatedList<BriefPostDto>>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetBriefPostQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PaginatedList<BriefPostDto>> Handle(GetBriefPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await _db.Posts
                .AsNoTracking()
                .OrderBy(x => x.LastModifiedAt)
                .ProjectTo<BriefPostDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return posts;
        }
    }
}
