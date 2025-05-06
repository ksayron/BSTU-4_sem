using lab6_MSSQL_LIB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace lab7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.Run();
        }
        public static IServiceCollection AddCelebritiesConfig(this WebApplicationBuilder builder, string CelebrityJson = "Celebrities.config.json")
        {
            builder.Configuration.AddJsonFile(CelebrityJson);
            return builder.Services.Configure<CelebritiesConfig>(builder.Configuration.GetSection("Celebrities"));
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
        }
    }
  
}
