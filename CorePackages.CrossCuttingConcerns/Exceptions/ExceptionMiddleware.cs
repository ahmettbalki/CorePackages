using CorePackages.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
namespace CorePackages.CrossCuttingConcerns.Exceptions;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    public ExceptionMiddleware(RequestDelegate netx)
    {
        _next = netx;
        _httpExceptionHandler = new HttpExceptionHandler();
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }catch (Exception ex)
        {
            await HandleExceptionAsync(context.Response, ex);
        }
    }
    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}
