using ClinicServiceHomework10.Models;

namespace ClinicServiceHomework10.Services
{
    // Интерфейс репоситория для животных
    public interface IPetRepository : IRepository<Pet, int>
    {
    }
}
