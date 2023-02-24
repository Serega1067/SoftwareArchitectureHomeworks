using ClinicServiceHomework11.Models;

namespace ClinicServiceHomework11.Services
{
    // Этот интерфейс репоситория будит унаследован от базового
    // интерфейса репоситория IRepository, где в качестве сущности
    // будит выступать Client и идентификатор клиента int
    public interface IClientRepository : IRepository<Client, int>
    {
        // void Delete(int clientId);
        // int Delete(int clientId);
    }

    // Мы спроектировали конкретный интерфейс репоситория клиента
}
