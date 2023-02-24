using ClinicServiceHomework11.Models;

namespace ClinicServiceHomework11.Services
{
    // Интерфейс репоситория для консультаций
    public interface IConsultationRepository : IRepository<Consultation, int>
    {
    }
}
