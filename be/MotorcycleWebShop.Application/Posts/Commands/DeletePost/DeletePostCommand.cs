using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Exceptions;

namespace MotorcycleWebShop.Application.Posts.Commands.DeletePost
{
    public record DeletePostCommand : IRequest
    {
        public int PostId { get; init; }
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IApplicationDbContext _db;

        public DeletePostCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _db.Posts.FindAsync(new object[] { request.PostId }, cancellationToken);

            if(post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
