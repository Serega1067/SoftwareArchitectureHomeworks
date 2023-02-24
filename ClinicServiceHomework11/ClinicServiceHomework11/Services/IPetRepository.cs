using ClinicServiceHomework11.Models;

namespace ClinicServiceHomework11.Services
{
    // Интерфейс репоситория для животных
    public interface IPetRepository : IRepository<Pet, int>
    {
    }
}
