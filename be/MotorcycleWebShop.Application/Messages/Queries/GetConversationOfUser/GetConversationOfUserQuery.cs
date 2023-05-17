using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;

namespace MotorcycleWebShop.Application.Messages.Queries.GetConversationOfUser
{
    public record GetConversationOfUserQuery : IRequest<GetConversationOfUserQueryResponse>
    {
        public int FromUserId { get; init; }
        public int ToUserId { get; init; }
    }

    public class GetConversationOfUserQueryHandler : IRequestHandler<GetConversationOfUserQuery, GetConversationOfUserQueryResponse>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetConversationOfUserQueryHandler(
            IApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<GetConversationOfUserQueryResponse> Handle(GetConversationOfUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetConversationOfUserQueryResponse();

            var messages = await _db.Messages.
                Where(x => (x.SenderId == request.FromUserId && x.ReceiverId == request.ToUserId) ||
                (x.SenderId == request.ToUserId && x.ReceiverId == request.FromUserId))
                .OrderBy(t => t.CreatedAt)
                .Include(a => a.Sender)
                .Include(a => a.Receiver)
                .ProjectTo<ChatMessageItem>(_mapper.ConfigurationProvider)
                .ToListAsync();

            response.Messages = messages;
            return response;
        }
    }

    public class GetConversationOfUserQueryResponse
    {
        public ICollection<ChatMessageItem> Messages { get; set; }
    }
}
