using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> Validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => Validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!Validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var errorsdictionary = Validators
            .Select(v => v.Validate(context))
            .SelectMany(v => v.Errors)
            .Where(v => v is not null)
            .GroupBy(
                v => v.PropertyName,
                v => v.ErrorMessage,
                (propertyname, errormesage) => new
                {
                    Key = propertyname,
                    Values = errormesage.Distinct().ToArray()
                }).ToDictionary(v => v.Key, v => v.Values);
        if (errorsdictionary.Any())
            throw new ValidationCustomException(errorsdictionary);
        return await next();
    }
}