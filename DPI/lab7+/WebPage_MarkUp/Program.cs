using System.Text.Json;
using WebPage_MarkUp.Models;
namespace WebPage_MarkUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddControllersWithViews();

            var booksJson = File.ReadAllText("books.json");
            var userJson = File.ReadAllText("users.json");
            var bookJson = File.ReadAllText("book.json");

            var books = JsonSerializer.Deserialize<List<Book>>(booksJson);
            var user = JsonSerializer.Deserialize<List<User>>(userJson);
            var book = JsonSerializer.Deserialize<BookDetailsViewModel>(bookJson);
            

            builder.Services.AddSingleton(new CatalogViewModel
            {
                Books = books,
                CurrentUser = user[0]
            });
            builder.Services.AddSingleton(book);

            var app = builder.Build();



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Book}/{id?}");

            app.Run();
        }
    }
}
