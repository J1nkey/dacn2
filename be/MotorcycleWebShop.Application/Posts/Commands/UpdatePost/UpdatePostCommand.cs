using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Application.Posts.Commands.UpdatePost
{
    public record UpdatePostCommand : IRequest
    {
        public int PostId { get; init; }
        public string Title { get; init; }
        public string Details { get; init; }
        public double KilometersConsumption { get; init; }
        public double CubicCentimeters { get; init; }
        public double HorsePower { get; init; }
        public double Torque { get; init; }
        public int MotorcycleId { get; init; }
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IApplicationDbContext _db;

        public UpdatePostCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            // check the post is existed
            var post = await _db.Posts.FindAsync(new object[] { request.PostId });

            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }

            post.Title = request.Title;
            post.Details = request.Details;
            post.CubicCentimeters = request.CubicCentimeters;
            post.Torque = request.Torque;
            post.HorsePower = request.HorsePower;
            post.MotorcycleId = request.MotorcycleId;
            post.KilometersConsumption = request.KilometersConsumption;

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
