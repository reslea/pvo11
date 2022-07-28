using FluentValidation;
using Newtonsoft.Json;
using System.Text;

namespace Booking.Web
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException validationException)
            {
                HandleValidation(validationException, context);
                return;
            }
            catch (AggregateException a) 
                when (a.InnerException is ValidationException validationException)
            {
                HandleValidation(validationException, context);
                return;
            }
        }

        private void HandleValidation(ValidationException validationException, HttpContext context)
        {
            context.Response.StatusCode = 400;

            var errorsJson = JsonConvert.SerializeObject(
                validationException.Errors
                    .Select(err => new 
                    { 
                        err.PropertyName, 
                        err.ErrorMessage 
                    }));
            
            var responseBytes = Encoding.UTF8.GetBytes(errorsJson);

            context.Response.BodyWriter.WriteAsync(responseBytes);
        }
    }
}
