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
                var acceptLang = context.Request.Headers.AcceptLanguage;
                if (acceptLang.Any())
                {
                    var lang = acceptLang[0].Substring(0, 2);
                    context.Session.SetString("lang", lang);
                }
            }
            await _next(context);
        }
    }
}
