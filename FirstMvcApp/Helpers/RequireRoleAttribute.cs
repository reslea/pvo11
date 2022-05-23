using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Helpers;

public class RequireRoleAttribute : TypeFilterAttribute
{
    public RequireRoleAttribute(string requiredRole)
        : base(typeof(RequreRoleFilter))
    {
        Arguments = new object[] { requiredRole };
    }
}
