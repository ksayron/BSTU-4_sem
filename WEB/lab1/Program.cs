//пространсто имен проекта
namespace lab1
{
    //обьвляем класс программы
    public class Program
    {
        //обьявляем входную функцию в программу
        public static void Main(string[] args)
        {
            //инициализируем обьект класса,задаующий начальную конфигурацию и подключает службы для приложения
            var builder = WebApplication.CreateBuilder(args);
            //подключаем сервис http логирования и задаем параметры логирования
            builder.Services.AddHttpLogging(o => { });
            //создаем приложание на основе конфигуратора
            var app = builder.Build();

            //настраиваем приложение на использование HtttpLogging middleware
            app.UseHttpLogging();
            //настраиваем ответ на GET запрос
            app.MapGet("/", () => "Мое первое ASPA");

            //запускаем приложение
            app.Run();
        }
    }
}
