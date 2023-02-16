using WebApplicationHomework9.Models;

namespace WebApplicationHomework9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // «арегестрируем наш сервис WeatherHolder в
            // инфраструктуре нашего приложени€, дл€ того чтобы
            // сервис смог дать ссылку на наш холдер
            // ќбратимс€ к сервисам и вызовим инструкцию
            builder.Services.AddSingleton<WeatherHolder>();
            // Ѕлагодор€ подобной инструкции мы зарегестрировали
            // в инфоструктуре приложени€ сервис WeatherForecast
            // это значит, что когда мы прот€гиваем зависимость
            // обного сервиса от другова и оба сервиса
            // зарегестрированы в инфроструктуре приложени€
            // приложение сама создаст объект и подсунит этот
            // объект в рамках зависимасти одного сервиса от другова,
            // то есть когда на вход придЄт, какой либо запрос,
            // например на добавление данных, то магическим оброзом
            // переменна€ holder не равна null, то есть приложение
            // создало экземпл€р класса WeatherHolder и передал его
            // и теперь этим компонентом можно пользоватьс€

            builder.Services.AddControllers(); // дл€ того чтобы
                                               // контроллеры работали
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}