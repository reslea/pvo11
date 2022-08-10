using Microsoft.AspNetCore.SignalR;

namespace SignalrSample;

public class ChatHub : Hub<IChatHubClient>
{
    public async Task SendMessage(string user, string message)
    {
        //await Clients.All.SendAsync("ReceiveMessage", user, message);

        await Clients.All.ReceiveMessage(user, message);
    }
}
