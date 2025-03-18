using lab3_LIB;
using Microsoft.Extensions.FileProviders;
using System;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDirectoryBrowser();
            var fileProvider = new PhysicalFileProvider("D:\\BSTU\\4sem\\WEB\\Lab3\\Ñelebrities\\");
            var requestPath = "/Celebrities/download";
            var app = builder.Build();
            app.UseStaticFiles(new StaticFileOptions

            {
                FileProvider = fileProvider,

                RequestPath = requestPath,

                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Content-Disposition", "attachment");
                }

            });

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = fileProvider,
                RequestPath = "/Celebrities/Download",
                
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            JSONCelebrityRepository.JSONFileName = "Ñelebrities.json";  // èìÿ ôàéëà
            using (ICelebrityRepository repository = JSONCelebrityRepository.Create("Celebrities"))
            {
                app.MapGet("/Celebrities",
                    () => repository.GetAll());

                app.MapGet("/Celebrities/{id:int}",
                    (int id) => repository.GetByID(id));

                app.MapGet("/Celebrities/BySurname/{surname}",
                    (string surname) => repository.GetBySurname(surname));

                app.MapGet("/Celebrities/PhotoPathById/{id:int}",
                    (int id) => repository.GetPhotoPathByID(id));
            }
            app.Run();
        }
    }
}
