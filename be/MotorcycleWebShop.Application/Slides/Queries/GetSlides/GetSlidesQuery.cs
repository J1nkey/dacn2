using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Slides.Queries.GetSlides
{
    public record GetSlidesQuery : IRequest<GetSlidesQueryResponse>
    {
    }

    public class GetSlidesQueryHandler : IRequestHandler<GetSlidesQuery, GetSlidesQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetSlidesQueryHandler(
            IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetSlidesQueryResponse> Handle(GetSlidesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSlidesQueryResponse();

            var slides = await _db.Slides
                .AsNoTracking()
                .ProjectTo<BaseSlideDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.SortOrder)
                .ToListAsync();

            response.Items = slides;

            return response;
        }
    }

    public class GetSlidesQueryResponse
    {
        public ICollection<BaseSlideDto> Items { get; set; }
    }
}
