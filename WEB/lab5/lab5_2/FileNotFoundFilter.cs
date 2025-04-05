using lab4_LIB;

namespace lab5_2
{
    public class FileNotFoundFilter : IEndpointFilter
    {
        public static ICelebrityRepository repository;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var celebrity = context.GetArgument<Celebrity>(0);
            var result = await next(context);

            string? fileName = Path.GetFileName(celebrity.PhotoPath);
            if (!File.Exists(Path.Combine(".", fileName)))
            {
                context.HttpContext.Response.Headers.Append("X-Celebrity", $"Not Found={fileName}");
            }

            return result;
        }
    }
}
