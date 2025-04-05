using lab4_LIB;

namespace lab5_2
{
    public class DeleteCoreFilter : IEndpointFilter
    {
        public static ICelebrityRepository repository;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            int id = context.GetArgument<int>(0);
            if (id>0 && id<8)
            {
                return Results.BadRequest("Core celebrity cannot be deleted");
            }

            return await next(context);
        }
    }
}
