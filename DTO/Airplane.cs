using System.Collections.Generic;

namespace DTO
{
    public class Airplane
    {
        public Airplane()
        {
            FlightLogs = new HashSet<FlightLog>();
        }

        public int AirplaneId { get; set; }
        public string TailNumber { get; set; }
        public string Name { get; set; }

        public ICollection<FlightLog> FlightLogs { get; set; }
    }
}