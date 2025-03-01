using Newtonsoft.Json;
using System.Net;

namespace Support.API.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            const HttpStatusCode code = HttpStatusCode.InternalServerError; 

            var result = JsonConvert.SerializeObject(new
            {
                status = code,
                error = exception.Message,
                stackTrace = exception.StackTrace
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
