using Serilog;

public sealed class ExceptionHandling : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            Log.Error(exception.Message);
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = await GetStatuseCode(exception);
        var error = new ErrorDetails
        {
            Title = await GetTitle(exception),
            Message = exception.Message,
            StatusCode = await GetStatuseCode(exception),
            ErrorsDictionaryValid = await GetErrorsMesage(exception)
        };
        await context.Response.WriteAsync(error.ToString());
    }

    private async Task<IReadOnlyDictionary<string, string[]>> GetErrorsMesage(Exception exception)
    {
        IReadOnlyDictionary<string, string[]> errors = null;
        if (exception is ValidationCustomException validexc)
            errors = validexc.ErrorsDictionary;
        return await Task.FromResult(errors);
    }

    private static async Task<int> GetStatuseCode(Exception exception) =>
        exception switch
        {
            BadRequestCustomException => StatusCodes.Status400BadRequest,
            NotFoundCustomException => StatusCodes.Status404NotFound,
            ValidationCustomException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

    private static async Task<string> GetTitle(Exception exception) =>
        exception switch
        {
            ApplicationExceptionCustom applicationExceptionCustom => applicationExceptionCustom.Title,
            _ => "Server Error"
        };
}