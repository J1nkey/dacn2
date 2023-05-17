using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<GetAllUsersQueryResponse>
    {
        public int CurrentUserId { get; init; }
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllUsersQueryResponse();

            var userBriefs = await _db.Users
                .AsNoTracking()
                .Where(u => u.Id != request.CurrentUserId)
                .ProjectTo<ApplicationUserBrief>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Users = userBriefs;

            return response;
        }
    }

    public class GetAllUsersQueryResponse
    {
        public ICollection<ApplicationUserBrief> Users { get; set; }
    }
}
