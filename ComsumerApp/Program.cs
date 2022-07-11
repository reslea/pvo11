using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connFactory = new ConnectionFactory { HostName = "localhost" };

using var connection = connFactory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = "new-test-queue";

channel.QueueDeclare(queueName, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += Consumer_Received;

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var messageText = Encoding.UTF8.GetString(e.Body.ToArray());
    var queue = e.RoutingKey;
    Console.WriteLine($"[o] queue: {queue} message: {messageText}");
}

channel.BasicConsume(queueName, true, consumer);

Console.ReadLine();