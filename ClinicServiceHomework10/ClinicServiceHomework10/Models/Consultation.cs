namespace ClinicServiceHomework10.Models
{
    public class Consultation
    {
        public int ConsultationId { get; set; }

        public int ClientId { get; set; }

        public int PetId { get; set; }

        public DateTime ConsultationDate { get; set; }

        public string Description { get; set; }
    }

    // Далее создадим контроллеры, которые позволят добавлять
    // некоторые объекты в рамках наших будущих таблиц
    // Напремер добавлять новых клиентов и животных, удалять этих
    // клиентов, создавать новые консультации, удалять эти
    // консультации
    // Если есть несколько сущностей и есть возможность разграничить
    // разгрупировать работу с этими сущностями, то было бы неплохо
    // создать несколько контроллеров, которые выполняют конкретную
    // работу
}
