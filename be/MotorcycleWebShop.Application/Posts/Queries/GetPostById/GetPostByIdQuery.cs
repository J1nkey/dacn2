using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Posts.Queries.GetPostById
{
    public record GetPostByIdQuery : IRequest<GetPostByIdQueryResponse>
    {
        public int Id { get; init; }
    }

    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetPostByIdQueryResponse();

            var postVm = await _db.Posts
                .AsNoTracking()
                .Where(t => t.Id == request.Id)
                .ProjectTo<PostViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            response.Data = postVm;
            return response;
        }
    }

    public class GetPostByIdQueryResponse
    {
        public PostViewModel Data { get; set; }
    }
}
