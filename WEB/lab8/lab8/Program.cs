using lab6_MSSQL_LIB;
using lab8.Models;

namespace lab8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IFileUploadService, FileUploadService>();
            builder.AddCelebritiesConfig();
            builder.AddCelebritiesServices();
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("Celebrities.config.json").Build();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapCelebrities(configuration);
            app.Run();
        }
    }
    static class BuilderExtension
    {

        public static IServiceCollection AddCelebritiesConfig(this WebApplicationBuilder builder, string CelebrityJson = "Celebrities.config.json")
        {
            builder.Configuration.AddJsonFile(CelebrityJson);
            return builder.Services.Configure<CelebritiesConfig>(builder.Configuration.GetSection("Celebrities"));
        }
        public static IServiceCollection AddCelebritiesServices(this WebApplicationBuilder builder, string CelebrityJson = "Celebrities.config.json")
        {
            builder.Services.AddScoped<IRepository, Repository>((p) =>
            {
                return new Repository(builder.Configuration.GetSection("Celebrities").GetValue<string>("ConnectionString"));
            });

            return builder.Services;
        }
        public static RouteHandlerBuilder MapCelebrities(this IEndpointRouteBuilder routeBuilder, IConfiguration config, string prefix = "/api/Celebrities")
        {
            var cel = routeBuilder.MapGroup("/api/Celebrities");
            cel.MapGet("/", (IRepository repo) => repo.GetAllCelebrity());
            //cel.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
            //{
            //    Celebrity? celebrity = repo.GetCelebById(id);
            //    if (celebrity == null) { throw new FoundByIDException($"Celebrity ID = ({id})"); }
            //    return celebrity;
            //});
            cel.MapGet("/LifeEvents/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                Celebrity? celebrity = repo.GetCelebByEventId(id);
                if (celebrity == null) { throw new FoundByIDException($"Celebrity ID = ({id})"); }
                return celebrity;
            });
            cel.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
            {
                if (repo.DelCelebrity(id))
                {
                    return Results.Ok(new { message = $"Celebrity with id:{id} deleted" });
                }
                else
                {
                    return Results.NotFound(new { error = $"DELETE /Celebrities error, Id = {id}" });
                }
            });
            cel.MapPost("/", async (HttpRequest request, IRepository repo, IWebHostEnvironment env) =>
            {
                var form = await request.ReadFormAsync();

                var name = form["FullName"];
                var nationality = form["Nationality"];
                var imgpath = form["ImgPath"];

                var celebrity = new Celebrity
                {
                    FullName = name!,
                    Nationality = nationality!,
                    ReqPhotoPath = imgpath
                };

                if (!repo.AddCelebrity(celebrity))
                    throw new SaveException("/Celebrities error SaveChanges <= 0");

                celebrity.Id = repo.GetCelebdByName(celebrity.FullName);

                return Results.Redirect($"/api/Celebrities/{celebrity.Id}");
            });
            cel.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebrity) =>
            {
                if (!repo.UpdCelebrity(id, celebrity)) { throw new SaveException("/Celebrities error SaveChanges <= 0"); }
                else celebrity.Id = repo.GetCelebdByName(celebrity.FullName);
                return celebrity;
            });
            return cel.MapGet("/photo/{fname}", async (IRepository repo, string fname) =>
            {
                var photoFolder = config.GetValue<string>("PhotosFolder");
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

    public class CelebritiesConfig
    {
        public string PhotosFolder { get; set; }
        public string ConnectionString { get; set; }
        public string PhotosRequestPath { get; set; }

        public CelebritiesConfig()
        {
            PhotosFolder = "./Photos";
            PhotosRequestPath = "/Photos";
            ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database = Lab6_DB; TrustServerCertificate=True; Trusted_Connection=true";
            ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database = Lab6_DB; TrustServerCertificate=True; Trusted_Connection=true";
        }
    }
    public class DeleteByIDException : Exception { public DeleteByIDException(string message) : base($"DeleteCelebrityException: {message}") { } }
    public class UpdateByIDException : Exception { public UpdateByIDException(string message) : base($"UpdateCelebrityException: {message}") { } }
    public class FileNotFoundException : Exception { public FileNotFoundException(string message) : base($"File Found: {message}") { } }
    public class FoundByIDException : Exception { public FoundByIDException(string message) : base($"Found By ID: {message}") { } }
    public class SaveException : Exception { public SaveException(string message) : base($"SaveChanges error: {message}") { } }
    public class AddCelebrityException : Exception { public AddCelebrityException(string message) : base($"AddCelebrityException error: {message}") { } }
    public class BadArgumentException : Exception { public BadArgumentException(string message) : base($"BadArgumentException error: {message}") { } }



}
