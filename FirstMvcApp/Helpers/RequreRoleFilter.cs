using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstMvcApp.Helpers;

public class RequreRoleFilter : IActionFilter
{
    private readonly ClaimsWrapper claimsWrapper;
    private readonly string requiredRole;

    public RequreRoleFilter(ClaimsWrapper claimsWrapper, string requiredRole = null)
    {
        this.claimsWrapper = claimsWrapper;
        this.requiredRole = requiredRole;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var isInRole = requiredRole == null
                   ? true
                   : claimsWrapper.Role == requiredRole;

        if (isInRole)
        {
            return;
        }

        context.Result = new ViewResult { ViewName = @"~/Views/Auth/LoginFailed" };
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}
