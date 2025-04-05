using lab4_LIB;

namespace lab5_2
{
    public class SurnameFilter : IEndpointFilter
    {
        public static ICelebrityRepository repository;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var celebrity = context.GetArgument<Celebrity>(0);
            if (string.IsNullOrWhiteSpace(celebrity.Surname) || celebrity.Surname.Length < 2)
            {
                return Results.BadRequest("Surname is wrong");
            }

            if(
                repository.GetBySurname(celebrity.Surname)!=null
                )
            {if (repository.GetBySurname(celebrity.Surname).Length > 0)
                {
                    return Results.BadRequest("Surname is doubled");
                }
            }

            return await next(context);
        }
    }
}
