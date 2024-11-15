using Microsoft.AspNetCore.SignalR;

namespace BlazorAppCarsCrud.Hubs
{
    public class ChatHub :Hub
    {
        public async Task SendMessage(DateTime Date,string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",Date, user, message);
        }
    }
}
