using Booking.Data.Entities;

namespace Booking.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string login, string password);
        string Register(User user);
    }
}
