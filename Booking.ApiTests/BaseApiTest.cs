using Booking.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Xunit;

namespace Booking.ApiTests
{
    public abstract class BaseApiTest
    {
        protected readonly HttpClient _client;

        public BaseApiTest()
        {
            var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder
                        .UseEnvironment("Test")
                        .ConfigureServices(services =>
                        {
                            //services.AddTransient<>

                            var provider = services.BuildServiceProvider();

                            var dbContext = provider.GetRequiredService<BookingDbContext>();

                            dbContext.Database.EnsureDeleted();
                        });
                });

            _client = app.CreateClient();
        }
    }
}