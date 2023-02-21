namespace ClinicServiceHomework10.Models
{
    public class Pet
    {
        // Свойства животного
        public int PetId { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
