using ClinicServiceHomework11.Services;
using ClinicServiceHomework11.Services.Impl;
using System.Data.SQLite;

namespace ClinicServiceHomework11
{
    // Работаем с sqlitestudio

    // Устанавливаем пакет Swashbuckle.AspNetCore.Annotations для
    // того чтобы можно было задовать дополнительные уникальные
    // имена в рамках генерации спецификации openAPI для методов
    // действий
    // И после этого пакет даст возможность в рамках контроллеров
    // каждому методу действия добавить уникальный атребут
    // Этот атрибут называется SwaggerOperation
    // Для того чтобы эта библиотека заработала необходимо добавить
    // в рамках главного метода main следующую настройку в рамках
    // вызова метода builder.Services.AddSwaggerGen() добавляем
    // дополнительную конфигурацию

    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            // Попробуем подключиться к базе данных, чтобы
            // убедиться, что всё сделано правельно
            // После создания базы данных функцию можно
            // закоментировать
            ConfigureSqlLiteConnection();
            */

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Нам нужно зарегестрировать наши новые сервисы
            // репозиториев в нашем контейнере, который занимается
            // тем что следит за тем какие компоненты нашей
            // программы зависят от других и если какому то
            // компоненту требуется другой компонент программы
            // он его подсовывает

            // Для регестрации нового сервиса необходимо выполнить
            // метод builder.Services.AddSingleton и указать тип
            // нашего сервиса <> его используют когда подсовывают
            // сервис, который был создан единажды и более ни когда
            // не будит создан
            // Мы же будим использовать другой метод при котором
            // каждый запрос обрабатывается в отдельном потоке и
            // создаются отдельные объекты столько сколько потребуется
            // то есть экземпляр этого сервиса должен быть создан
            // в контексте обрабатки конкретного запроса
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
            {
                config.EnableAnnotations();
            });

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

        // Подготовим работу с базой данных
        private static void ConfigureSqlLiteConnection()
        {
            // Подключимся к базе данных
            const string connectionString = "Data Source = clinic.db; " +
                "Version = 3; Pooling = true; Max Pool Size = 100;";

            // Важное правило не надо держать постоянное подключение
            // к базе данных подключились, поработали с базой данных,
            // отключились
            // В созданной строке содержатся параметры с которыми мы
            // будим подключаться к базе данных

            // Предназначение этого класса это создание на базе
            // этого класса объекта, который представляет из себя
            // соединение с базой данных
            SQLiteConnection connection = new SQLiteConnection(
                                          connectionString);

            // Мы указали строку соединения и теперь попытаемся
            // подключиться к базе данных, если она существует,
            // если нет то её надо создать
            connection.Open();

            PrepareScheme(connection);
        }

        // Чтобы программно добавить в базу данных, какие нибуть
        // таблици создадим новый метод и в качестве параметра
        // передадим сюда ссылку на объект подключения к базе
        // данных, так как для того чтобы создавать какие то
        // объекты в базе данных или вообще с ней взаимодействовать
        // нам всегда потребуется объект подключения к базе данных
        private static void PrepareScheme(SQLiteConnection connection)
        {
            /*
            // Так как в SQLite нет типа данных даты сделаем так
            DateTime.Now.Ticks; // возвращает значение типа Long
            // Даты будим хранить в тактах
            */

            // Предположим нам надо создать новую таблицу
            SQLiteCommand command = new SQLiteCommand(connection);

            // Далее у объекта command существует главное свойство
            // это свойство называется CommandText в рамках этого
            // свойства мы можем указать, какие то запросы которые
            // мы можем послать к нашей базе данных

            /*
            // Команда на удаление таблиц, если они есть
            command.CommandText = "DROP TABLE IF EXISTS consultations";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS pets";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS clientsf";
            command.ExecuteNonQuery();
            */

            // Сделаем запрос на создание новой таблици
            command.CommandText = @"CREATE TABLE Clients(
                                    ClientId INTEGER PRIMARY KEY,
                                    Document TEXT,
                                    SurName TEXT,
                                    FirstName TEXT,
                                    Patronymic TEXT,
                                    Birthday INTEGER)";

            // Мы создали команду теперь её выполним
            command.ExecuteNonQuery(); // этот метод говорит, что
                                       // мы хотим выполнить команду
                                       // и при этом мы не ждём ни
                                       // каких выходных данных

            command.CommandText =
                @"CREATE TABLE Pats(
                  PetsId INTEGER PRIMARY KEY,
                  ClientId INTEGER,
                  Name TEXT,
                  Birthday INTEGER)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Consultations(
                  ConsultationId INTEGER PRIMARY KEY,
                  ClientId INTEGER,
                  PetsId INTEGER,
                  ConsultationDate INTEGER,
                  Description TEXT)";
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}