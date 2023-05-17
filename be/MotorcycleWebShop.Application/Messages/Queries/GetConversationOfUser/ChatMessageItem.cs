using AutoMapper;
using MotorcycleWebShop.Application.Common.Mapping;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Messages.Queries.GetConversationOfUser
{
    public class ChatMessageItem : IMapFrom<Message>
    {
        public int Id { get; set; }
        public string MessageValue { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, ChatMessageItem>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.MessageValue, opt => opt.MapFrom(d => d.MessageValue))
                .ForMember(s => s.SenderId, opt => opt.MapFrom(d => d.SenderId))
                .ForMember(s => s.ReceiverId, opt => opt.MapFrom(d => d.ReceiverId))
                .ForMember(s => s.Sender, opt => opt.MapFrom(d => d.Sender))
                .ForMember(s => s.Receiver, opt => opt.MapFrom(d => d.Receiver))
                .ForMember(s => s.CreatedAt, opt => opt.MapFrom(d => d.CreatedAt));
        }
    }
}
