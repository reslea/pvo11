using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connFactory = new ConnectionFactory { HostName = "localhost" };

using var connection = connFactory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = "emails-to-send";

channel.QueueDeclare(queueName, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += Consumer_Received;

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var messageText = Encoding.UTF8.GetString(e.Body.ToArray());
    var queue = e.RoutingKey;
    Console.WriteLine($"[o] email sent with details: {messageText}");
}

channel.BasicConsume(queueName, true, consumer);

Console.WriteLine("waiting data to send...");
Console.ReadLine();