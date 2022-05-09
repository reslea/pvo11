using System.Security.Claims;

namespace FirstMvcApp.Services
{
    public interface IAuthService
    {
        ClaimsPrincipal Login(string email, string password);
    }
}