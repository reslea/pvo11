using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var connFactory = new ConnectionFactory { HostName = "localhost" };

using var connection = connFactory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = "new-test-queue";
channel.QueueDeclare(queueName, exclusive: false);

while (true)
{
    var paymentMessage = new
    {
        OrderId = 15,
        PlaymentStatus = "Success",
        Date = DateTime.Now,
    };
    SendMessage(paymentMessage);
    await Task.Delay(TimeSpan.FromSeconds(1));
}

Console.ReadLine();

byte[] GetMessageBytes(string messageText) => Encoding.UTF8.GetBytes(messageText);

void SendMessage(object obj)
{
    var json = JsonConvert.SerializeObject(obj);
    channel.BasicPublish("", queueName, null, GetMessageBytes(json));
    Console.WriteLine($"[x] Sent: {json}");
}