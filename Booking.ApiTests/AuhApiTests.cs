using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.ApiTests
{
    public class AuhApiTests : BaseApiTest
    {
        [Fact]
        public async void Registration_Token_Valid()
        {
            var registrationResponse = await RegisterNewUserRequest();

            Assert.True(registrationResponse.IsSuccessStatusCode);
            var token = await registrationResponse.Content.ReadAsStringAsync();

            var tokenCheckResponse = await CheckTokenRequest(token);

            Assert.True(tokenCheckResponse.IsSuccessStatusCode);

            async Task<HttpResponseMessage> RegisterNewUserRequest()
            {
                var newUser = new
                {
                    Name = "Alex",
                    Email = "a@gmail.com",
                    Password = "123",
                    Age = 20
                };

                var newUserJson = JsonConvert.SerializeObject(newUser);
                var encoding = Encoding.UTF8;
                var contentType = "application/json";

                var registrationResponse = await _client.PostAsync("api/auth/register",
                    new StringContent(newUserJson, encoding, contentType));
                return registrationResponse;
            }

            async Task<HttpResponseMessage> CheckTokenRequest(string token)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "api/auth");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var tokenCheckResponse = await _client.SendAsync(request);
                return tokenCheckResponse;
            }
        }
    }
}
