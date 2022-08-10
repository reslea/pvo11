public interface IChatHubClient
{
    Task JoinChat(string name);
    Task ReceiveMessage(string name, string message);
}