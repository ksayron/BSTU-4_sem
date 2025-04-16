using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using lab6_MSSQL_LIB;
using Microsoft.AspNetCore.Diagnostics;
using lab6_LIB;
using Microsoft.Extensions.Logging;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
namespace lab6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string CS = "Server=(LocalDb)\\MSSQLLocalDB; Database = Lab6_DB; TrustServerCertificate=True; Trusted_Connection=true";
            Init init = new Init(CS);
            Init.Execute(create: true, delete: true);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("Celebrities.config.json").Build();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRepository, Repository>((p) =>
            {
                CelebritiesConfig config = p.GetRequiredService<IOptions<CelebritiesConfig>>().Value;
                return new Repository(configuration.GetSection("Celebrities").GetSection("ConnectionString").Value);
            });

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            var photoFolder = configuration.GetSection("Celebrities").GetSection("PhotosFolder").Value;
            if (!Directory.Exists(photoFolder)) { throw new Exception("incorrect photo folder"); }
            app.UseExceptionHandler("/Celebrities/Error");

            //-------------------Celebrities--------------------------
            var cel = app.MapGroup("/api/Celebrities");
            cel.MapGet("/", (IRepository repo) => repo.GetAllCelebrity());
            cel.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.GetCelebById(id);
                if (celebrity == null) { throw new FoundByIDException($"Celebrity ID = ({id})"); }
                return celebrity;
            });
            cel.MapGet("/LifeEvents/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.GetCelebByEventId(id);
                if (celebrity == null) { throw new FoundByIDException($"Celebrity ID = ({id})"); }
                return celebrity;
            });
            cel.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                if (repo.DelCelebrity(id)) { return $"Celebrity with id:{id} deleted"; }
                else { throw new DeleteByIDException($"DELETE /Celebrities error, Id = {id}"); }
            });
            cel.MapPost("/", (IRepository repo, Celebrity celebrity) =>
            {

                if (!repo.AddCelebrity(celebrity)) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                else celebrity.Id = repo.GetCelebdByName(celebrity.FullName);
                return celebrity;
            });
            cel.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebrity) =>
            {
                if (!repo.UpdCelebrity(id, celebrity)) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                else celebrity.Id = repo.GetCelebdByName(celebrity.FullName);
                return celebrity;
            });
            cel.MapGet("/photo/{fname}", async (IRepository repo,string fname) =>
            {
                var photoPath = Path.Combine(photoFolder, fname);
                if (!File.Exists(photoPath)) { throw new FileNotFoundException($" {fname} was not found"); }
                else
                {
                    try
                    {
                        // Возвращаем найденный файл
                        var bytes = await File.ReadAllBytesAsync(photoPath);
                        string contentType = GetContentTypeByExtension(Path.GetExtension(photoPath));
                        return Results.File(bytes, contentType);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                        return Results.Problem($"Ошибка при чтении файла: {ex.Message}");
                    }
                }
            });

            //-------------------LifeEvents----------------------------
            var lf = app.MapGroup("/api/LifeEvents");
            lf.MapGet("/", (IRepository repo) => repo.GetAllEvents());
            lf.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                LifeEvent? @event = repo.GetEventById(id);
                if (@event == null) { throw new FoundByIDException($"Event ID = ({id})"); }
                return @event;
            });
            lf.MapGet("/Celebrities/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                List<LifeEvent> @event = repo.GetEventsByCelebId(id);
                if (@event == null) { throw new FoundByIDException($"Events for Celebrity ID = ({id})"); }
                return @event;
            });
            lf.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                if (repo.DelEvent(id)) { return $"LifeEvent with id:{id} deleted"; }
                else { throw new DeleteByIDException($"DELETE /LifeEvents error, Id = {id}"); }
            });
            lf.MapPost("/", (IRepository repo, LifeEvent @event) =>
            {

                if (!repo.AddEvent(@event)) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                else @event.Id = repo.GetEventsByCelebId(@event.CelebrityId).Last().Id;
                return @event;
            });
            lf.MapPut("/{id:int:min(1)}", (IRepository repo, int id, LifeEvent @event) =>
            {
                if (!repo.UpdEvent(id, @event)) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                else @event.Id = repo.GetEventsByCelebId(@event.CelebrityId).Last().Id;
                return @event;
            });
            
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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        public class CelebritiesConfig
        {
            public string PhotosFolder { get; set; }
            public string ConnectionString { get; set; }
        }
        public class DeleteByIDException : Exception { public DeleteByIDException(string message) : base($"DeleteCelebrityException: {message}") { } }
        public class UpdateByIDException : Exception { public UpdateByIDException(string message) : base($"UpdateCelebrityException: {message}") { } }
        public class FileNotFoundException : Exception { public FileNotFoundException(string message) : base($"File Found: {message}") { } }
        public class FoundByIDException : Exception { public FoundByIDException(string message) : base($"Found By ID: {message}") { } }
        public class SaveException : Exception { public SaveException(string message) : base($"SaveChanges error: {message}") { } }
        public class AddCelebrityException : Exception { public AddCelebrityException(string message) : base($"AddCelebrityException error: {message}") { } }
        public class BadArgumentException : Exception { public BadArgumentException(string message) : base($"BadArgumentException error: {message}") { } }

        static string GetContentTypeByExtension(string extension)
        {
            return extension.ToLower() switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream",
            };
        }
    }
}

