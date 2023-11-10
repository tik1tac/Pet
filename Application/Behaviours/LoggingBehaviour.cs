using MediatR;
using Serilog;

namespace Application.Behaviours;

public class LoggingBehaviour<TRequset, TResponse> : IPipelineBehavior<TRequset, TResponse>
    where TRequset : notnull
{
    public async Task<TResponse> Handle(TRequset request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Log.Information($"Handling {typeof(TRequset).Name}");
        var response = await next();
        Log.Information($"Handled {typeof(TRequset).Name}");
        return response;
    }
}