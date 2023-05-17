using Microsoft.AspNetCore.SignalR;
using MotorcycleWebShop.Application.Messages.Commands.CreateMessage;

namespace MotorcycleWebShop.Application.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(CreateMessageCommand message, string userName)
        {
            await Clients.All.SendAsync("ReceiveMessage", message, userName);
        }

        public async Task ChatNotificationAsync(string message, int senderId, int receiverId)
        {
            await Clients.All.SendAsync("ReceiveNotification", message, senderId, receiverId);
        }
    }
}
