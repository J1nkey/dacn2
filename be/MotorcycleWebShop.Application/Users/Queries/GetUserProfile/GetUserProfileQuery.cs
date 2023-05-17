using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Users.Queries.GetUserProfile
{
    public record GetUserProfileQuery : IRequest<UserProfileDto>
    {
        public int UserId { get; init; }
    }

    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {

            var user = _db.Users.Where(x => x.Id == request.UserId)
                .ProjectTo<UserProfileDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            }

            if (_db.Providers.Any(x => x.ApplicationUserId == user.UserId) == true)
            {
                user.IsProvider = true;
            }
            else
            {
                user.IsProvider = false;
            }

            return user;
        }
    }
}
