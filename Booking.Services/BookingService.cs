using Booking.Data;
using Booking.Data.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Booking.Services
{
    public class BookingService : IBookingService, IDisposable
    {
        private readonly BookingDbContext context;
        private readonly IConnection _connection;
        private IModel _channel;
        private const string _queueName = "emails-to-send";

        public BookingService(
            BookingDbContext context, 
            ConnectionFactory connectionFactory)
        {
            this.context = context;

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(_queueName, exclusive: false);
        }

        public void CreateBooking(RoomBooking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();

            var bookingJsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(booking));

            _channel.BasicPublish("", _queueName, null, bookingJsonBytes);
        }

        public void AddBookingDetails(BookingDetails details)
        {
            var detailsFromDb = context.BookingDetails
                .FirstOrDefault(d => d.Id == details.Id);

            bool isArrival = detailsFromDb == null;

            if (isArrival)
            {
                context.BookingDetails.Add(details);
                context.SaveChanges();
            }
            else
            {
                detailsFromDb.LeaveDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
