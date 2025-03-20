using Microsoft.AspNetCore.Diagnostics;

namespace Lab2_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics", LogLevel.None);
            // Add services to the container.
            builder.Services.AddRazorPages();
            
            var app = builder.Build();
            //app.UseHttpLogging();
            app.UseExceptionHandler("/error");
            app.MapGet("/", () => "Start");
            app.MapGet("/test1", () => 
            {
                throw new Exception("-- Exeption test --");
            });
            app.MapGet("/test2", () =>
            {
                int x = 0, y = 5, z = 0;
                z = y / x;
                return "test2";
            });
            app.MapGet("/test3", () =>
            {
                int[] x = new int[3] { 1, 2, 3 };
                int y = x[3];
                return "test3";
            });
            app.Map("/error", async (ILogger<Program> logger, HttpContext context) =>
            {
                IExceptionHandlerFeature? exobj = context.Features.Get<IExceptionHandlerFeature>();
                await context.Response.WriteAsync($"<h1>Oops!</h1>");
                logger.LogError(exobj?.Error, "ExceptionHandler");
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.Run();
        }
    }
}
