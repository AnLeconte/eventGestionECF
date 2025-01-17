using eventGestion.Models.EventItems;

namespace EventManagement.Models
{
   public class Participant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int EventId { get; set; }
        public required Event Event { get; set; }
    }
}


