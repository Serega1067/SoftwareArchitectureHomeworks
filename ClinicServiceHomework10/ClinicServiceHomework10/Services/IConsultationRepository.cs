using ClinicServiceHomework10.Models;

namespace ClinicServiceHomework10.Services
{
    // Интерфейс репоситория для консультаций
    public interface IConsultationRepository : IRepository<Consultation, int>
    {
    }
}
