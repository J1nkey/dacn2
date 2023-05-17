using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Title { get;init; }
        public string Details { get;init; }
        public double KilometersConsumption { get; init; }
        public double CubicCentimeters { get; init; }
        public double HorsePower { get; init; }
        public double Torque { get; init; }
        public int MotorcycleId { get; init; }
        public int ProviderId { get; init; }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreatePostCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(new object[] { request.UserId });

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            }

            // check user is a provider
            var provider =  _db.Providers.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
            if(provider == null)
            {
                throw new NotFoundException(nameof(Provider), request.UserId);
            }

            if (!(_db.Motorcycles.Any(x => x.Id == request.MotorcycleId)))
            {
                throw new NotFoundException(nameof(Motorcycle), request.MotorcycleId);
            }

            Post post = new Post
            {
                Title = request.Title,
                Details = request.Details,
                CubicCentimeters = request.CubicCentimeters,
                KilometersConsumption = request.KilometersConsumption,
                HorsePower = request.HorsePower,
                Torque = request.Torque,
                ProviderId = request.ProviderId,
                MotorcycleId = request.MotorcycleId
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
