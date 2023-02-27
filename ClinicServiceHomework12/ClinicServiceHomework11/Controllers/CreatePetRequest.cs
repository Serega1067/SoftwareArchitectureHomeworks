namespace ClinicServiceHomework11.Controllers
{
    public class CreatePetRequest
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
