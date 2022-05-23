using System.Security.Claims;

namespace FirstMvcApp.Helpers
{
    public class ClaimsWrapper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ClaimsWrapper(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public bool IsAuthenticated => contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

        public int? UserId =>
            IsAuthenticated
            ? int.Parse(contextAccessor.HttpContext!.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            : null;

        public string? UserName =>
            IsAuthenticated
            ? contextAccessor.HttpContext!.User.Claims.First(c => c.Type == ClaimTypes.Name).Value
            : null;

        public string? Role =>
            IsAuthenticated
            ? contextAccessor.HttpContext!.User.Claims.First(c => c.Type == ClaimTypes.Role).Value
            : null;
    }
}
