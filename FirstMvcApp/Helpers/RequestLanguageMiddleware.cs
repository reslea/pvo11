namespace FirstMvcApp.Helpers
{
    public class RequestLanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var lang = context.Request.Headers.AcceptLanguage[0].Substring(0, 2);
            context.Items["USER_PRIMARY_LANG"] = lang;

            await _next(context);
        }
    }
}
