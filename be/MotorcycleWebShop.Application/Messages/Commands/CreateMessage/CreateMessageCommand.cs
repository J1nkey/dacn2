using MediatR;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Messages.Commands.CreateMessage
{
    public record CreateMessageCommand : IRequest<int>
    {
        public string MessageValue { get; init; }
        public int SenderId { get; init; }
        public int ReceiverId { get; init; }
    }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateMessageCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message();
            message.MessageValue = request.MessageValue;
            message.SenderId = request.SenderId;
            message.Receiver =
                _db.Users.Where(x => x.Id == request.ReceiverId).FirstOrDefault();

            _db.Messages.Add(message);
            return await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
