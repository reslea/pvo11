namespace SampleApi
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
            var existingLang = context.Session.GetString("lang");
            if (string.IsNullOrEmpty(existingLang))
            {
                var lang = context.Request.Headers.AcceptLanguage[0].Substring(0, 2);
                context.Session.SetString("lang", lang);
            }
            await _next(context);
        }
    }
}
