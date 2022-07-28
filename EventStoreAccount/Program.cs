using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using System.Net;
using System.Text;

var esConnection = EventStoreConnection.Create(
    new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));

await esConnection.ConnectAsync();

var credentials = new UserCredentials("admin", "changeit");

var eventSlice = await esConnection
    .ReadStreamEventsForwardAsync("Account-John", 0, 100, false, credentials);

foreach (var @event in eventSlice.Events)
{
    var jsonBytes = @event.Event.Data;
    var json = Encoding.UTF8.GetString(jsonBytes);
    Console.WriteLine(json);
}