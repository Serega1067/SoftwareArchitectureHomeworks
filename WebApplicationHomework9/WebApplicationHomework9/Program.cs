using WebApplicationHomework9.Models;

namespace WebApplicationHomework9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // �������������� ��� ������ WeatherHolder �
            // �������������� ������ ����������, ��� ���� �����
            // ������ ���� ���� ������ �� ��� ������
            // ��������� � �������� � ������� ����������
            builder.Services.AddSingleton<WeatherHolder>();
            // ��������� �������� ���������� �� ����������������
            // � ������������� ���������� ������ WeatherForecast
            // ��� ������, ��� ����� �� ����������� �����������
            // ������ ������� �� ������� � ��� �������
            // ���������������� � �������������� ����������
            // ���������� ���� ������� ������ � �������� ����
            // ������ � ������ ����������� ������ ������� �� �������,
            // �� ���� ����� �� ���� �����, ����� ���� ������,
            // �������� �� ���������� ������, �� ���������� �������
            // ���������� holder �� ����� null, �� ���� ����������
            // ������� ��������� ������ WeatherHolder � ������� ���
            // � ������ ���� ����������� ����� ������������

            builder.Services.AddControllers(); // ��� ���� �����
                                               // ����������� ��������
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