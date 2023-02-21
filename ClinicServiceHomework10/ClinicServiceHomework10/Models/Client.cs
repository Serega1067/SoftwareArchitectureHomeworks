namespace ClinicServiceHomework10.Models
{
    public class Client
    {
        // Добавляем в рамках нашей главной сущности соответствующие
        // поля  или точнее свойства
        public int ClientId { get; set; }

        public string Document { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}
