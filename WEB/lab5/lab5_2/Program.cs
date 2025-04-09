using Microsoft.Extensions.FileProviders;
using lab4_LIB;
using Microsoft.AspNetCore.Diagnostics;

namespace lab5_2
{
    public class Program
    {
        public static void Main(string[] args)
        {       
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDirectoryBrowser();
            var requestPath = "/Celebrities/download";
            var app = builder.Build();
            app.UseStaticFiles();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            JSONCelebrityRepository.JSONFileName = "Ñelebrities.json";  // èìÿ ôàéëà
            using (ICelebrityRepository repository = JSONCelebrityRepository.Create("Celebrities"))
            {
                RouteGroupBuilder api = app.MapGroup("/Celebrities");
                SurnameFilter.repository = FileNotFoundFilter.repository = FileNotFoundPutFilter.repository =
                FoundByIDFilter.repository = SurnameFilter.repository = repository;

                app.UseExceptionHandler("/Celebrities/Error");
                api.MapGet("/",
                    () => repository.GetAll());

                api.MapGet("/{id:int}",
                    (int id) => {
                        Celebrity? celebrity = repository.GetByID(id);
                        if (celebrity == null) { throw new FoundByIDException($"Celebrity ID = ({id})"); }
                        return celebrity;
                    });
                
                api.MapPost("/", (Celebrity celebrity) =>
                {
                    int? id = repository.AddCelebrity(celebrity);
                    if (id == null) { throw new AddCelebrityException("/Celebrities error id == null"); }
                    if (repository.SaveChanges() <= 0) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                    return new Celebrity((int)id, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
                })
                 .AddEndpointFilter<SurnameFilter>()
                 .AddEndpointFilter<FileNotFoundFilter>();

                app.MapFallback((HttpContext ctx) => Results.NotFound(new { error = $"path {ctx.Request.Path} not supported" }));
                api.MapDelete("/{id:int}", (int id) =>
                {
                    if (repository.DeleteCelebrity(id)) { return $"Celebrity with id:{id} deleted"; }
                    else { throw new DeleteByIDException($"DELETE /Celebrities error, Id = {id}"); }
                })
                .AddEndpointFilter<DeleteCoreFilter>();
                api.MapPut("/{id:int}", (int id, Celebrity celebrity) =>
                {
                    var res = repository.UpdateCelebByID(id, celebrity);
                    if (res != null)
                    {
                        return new Celebrity((int)res, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
                    }
                    else { throw new UpdateByIDException($"Put /Celebrities error, Id = {id}"); }
                })
                .AddEndpointFilter<FileNotFoundPutFilter>();
                app.Map("/Celebrities/Error", (HttpContext ctx) =>
                {
                    Exception? ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
                    IResult rc = Results.Problem(detail: "Panic", instance: app.Environment.EnvironmentName, title: "ASPA004", statusCode: 500);
                    if (ex != null)
                    {
                        if (ex is DeleteByIDException) { rc = Results.NotFound(ex.Message); }
                        if (ex is FileNotFoundException) { rc = Results.Problem(title: "ASPA004", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 500); }
                        if (ex is FoundByIDException) { rc = Results.NotFound(ex.Message); }//404
                        if (ex is BadHttpRequestException) { rc = Results.BadRequest(ex.Message); }//400
                        if (ex is SaveException) { rc = Results.Problem(title: "ASPA004/SaveChanges", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 500); }
                        if (ex is AddCelebrityException) { rc = Results.Problem(title: "ASPA004/addCelebrity", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 500); }
                        if (ex is UpdateByIDException) { rc = Results.Problem(title: "ASPA004/updateCelebrity", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 500); }
                        if (ex is BadArgumentException) { rc = Results.Problem(title: "ASPA004/addCelebrity", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 409); }
                    }
                    return rc;
                });

                api.MapGet("/BySurname/{surname}",
                    (string surname) => repository.GetBySurname(surname));

                api.MapGet("/PhotoPathById/{id:int}",
                    (int id) => repository.GetPhotoPathByID(id));
            }
            app.Run();
        }
        public class DeleteByIDException : Exception { public DeleteByIDException(string message) : base($"DeleteCelebrityException: {message}") { } }
        public class UpdateByIDException : Exception { public UpdateByIDException(string message) : base($"UpdateCelebrityException: {message}") { } }
        public class FileNotFoundException : Exception { public FileNotFoundException(string message) : base($"File Found: {message}") { } }
        public class FoundByIDException : Exception { public FoundByIDException(string message) : base($"Found By ID: {message}") { } }
        public class SaveException : Exception { public SaveException(string message) : base($"SaveChanges error: {message}") { } }
        public class AddCelebrityException : Exception { public AddCelebrityException(string message) : base($"AddCelebrityException error: {message}") { } }
        public class BadArgumentException : Exception { public BadArgumentException(string message) : base($"BadArgumentException error: {message}") { } }
    }
}
