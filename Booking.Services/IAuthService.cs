using Booking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public interface IAuthService
    {
        string Login(string login, string password);
        string Register(User user);
    }
}
