using Booking.Data;
using Booking.Data.Entities;
using Booking.Services.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System.Text;

namespace Booking.Services
{
    public class BookingService : IBookingService, IDisposable
    {
        private readonly ILogger<BookingService> logger;
        private readonly BookingDbContext context;
        private readonly ConnectionFactory connectionFactory;
        private readonly IHubContext<BookingHub, IBookingClient> bookingHubContext;
        private IConnection _connection;
        private IModel _channel;
        private const string _queueName = "emails-to-send";

        public BookingService(
            ILogger<BookingService> logger,
            BookingDbContext context, 
            ConnectionFactory connectionFactory,
            IHubContext<BookingHub, IBookingClient> bookingHubContext)
        {
            this.logger = logger;
            this.context = context;
            this.connectionFactory = connectionFactory;
            this.bookingHubContext = bookingHubContext;
        }

        public void CreateBooking(RoomBooking booking)
        {
            context.RoomBookings.Add(booking);
            context.SaveChanges();

            var bookingJson = JsonConvert.SerializeObject(booking, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            logger.LogInformation("room booked: {0}", bookingJson);
            bookingHubContext.Clients.All.RoomBooked(bookingJson);

            var bookingJsonBytes = Encoding.UTF8.GetBytes(bookingJson);
            InitQueue();
            _channel.BasicPublish("", _queueName, null, bookingJsonBytes);
        }

        public async Task AddBookingDetailsAsync(BookingDetails details)
        {
            var detailsFromDb = await context.BookingDetails
                .FirstOrDefaultAsync(d => d.Id == details.Id);

            bool isArrival = detailsFromDb == null;

            if (isArrival)
            {
                context.BookingDetails.Add(details);
                await context.SaveChangesAsync();
            }
            else
            {
                detailsFromDb.LeaveDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }

        public async Task<List<RoomBooking>> GetBookings(DateTime? date)
        {
            return await context.RoomBookings
                .Where(b => b.DateFrom <= date && b.DateTo >= date)
                .ToListAsync();
        }

        private void InitQueue()
        {
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(_queueName, exclusive: false);
        }
    }
}
