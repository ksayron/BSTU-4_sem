﻿using lab4_LIB;
namespace lab5_2

{
    public class FoundByIDFilter : IEndpointFilter
    {
        public static ICelebrityRepository repository;
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            int id = context.GetArgument<int>(0);

            if (repository.GetByID(id) == null)
            {
                return Results.Conflict($"Celebrity by id={id} Not Found");
            }

            return await next(context);
        }
    }
}
