using EventManagement.Models;

namespace eventGestion.Models.EventItems
{
    public class Event
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime Date { get; set; }

        public int MaxParticipants { get; set; }

        public required List<Participant> Participants { get; set; }  
    }

}



