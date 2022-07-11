using Booking.Data.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var connFactory = new ConnectionFactory { HostName = "localhost" };

using var connection = connFactory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = "booking-client-events";
channel.QueueDeclare(queueName, exclusive: false);

Console.WriteLine("Please enter booking number:");
var bookingId = int.Parse(Console.ReadLine());

var arrivalDetails = new BookingDetails
{
    BoookingId = bookingId,
    ArrivalDate = DateTime.Now,
};

SendMessage(arrivalDetails);

//Console.WriteLine("Press enter when you leave:");
//Console.ReadLine();

//var leaveDetails = new BookingDetails
//{
//    BoookingId = bookingId,
//    LeaveDate = DateTime.Now,
//};
//SendMessage(leaveDetails);

Console.ReadLine();

byte[] GetMessageBytes(string messageText) => Encoding.UTF8.GetBytes(messageText);

void SendMessage(object obj)
{
    var json = JsonConvert.SerializeObject(obj);
    channel.BasicPublish("", queueName, null, GetMessageBytes(json));
    Console.WriteLine($"[x] Sent: {json}");
}