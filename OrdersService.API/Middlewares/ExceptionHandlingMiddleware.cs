using System.Net;
using OrdersService.Domain.Exceptions;

namespace OrdersService.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception error)
        {
            switch (error)
            {
                case OrderIdException e:

                    await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, e.Message, error.Message);
                    break;

                case OrderStatusException e:

                    await HandleExceptionAsync(httpContext, HttpStatusCode.Forbidden, e.Message, error.Message);
                    break;

                default:
                    await HandleExceptionAsync(httpContext, HttpStatusCode.Forbidden, error.Message,
                        error.Message);
                    break;
            }
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message,
        string exceptionMessage)
    {
        var responce = context.Response;
        responce.ContentType = "application/json";
        responce.StatusCode = (int) statusCode;
        
        await responce.WriteAsJsonAsync(message);
    }
}