using FluentValidation;

namespace Minimal.Auth.Api.Interface.Filters
{
    public class ValidatorFilter<T> : IEndpointFilter
    {
        private readonly IValidator<T> _validator;

        public ValidatorFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validatable = (T) context.Arguments
                                .SingleOrDefault(arg => 
                                    arg?.GetType() == typeof(T))!;

            if (validatable is null)
            {
                return Results.BadRequest();
            }

            var validation = await _validator.ValidateAsync(validatable);

            if (!validation.IsValid)
            {
                return Results.BadRequest(validation.Errors.ToString());
            }

            var result = await next(context);

            return result;
        }
    }
}
