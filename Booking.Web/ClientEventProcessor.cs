using Booking.Data.Entities;
using Booking.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Booking.Web
{
    public class ClientEventProcessor : IHostedService
    {
        private readonly ConnectionFactory connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider serviceProvider;
        
        const string _queueName = "booking-client-events";

        public ClientEventProcessor(
            ConnectionFactory connectionFactory,
            IServiceProvider serviceProvider)
        {
            this.connectionFactory = connectionFactory;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(_queueName, exclusive: false);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            void Consumer_Received(object? sender, BasicDeliverEventArgs e)
            {
                var messageJson = Encoding.UTF8.GetString(e.Body.ToArray());

                var bookingDetails = JsonConvert.DeserializeObject<BookingDetails>(messageJson);

                using var scope = serviceProvider.CreateScope();

                var bookingService = scope.ServiceProvider.GetRequiredService<IBookingService>();

                bookingService.AddBookingDetails(bookingDetails);
            }

            _channel.BasicConsume(_queueName, true, consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
