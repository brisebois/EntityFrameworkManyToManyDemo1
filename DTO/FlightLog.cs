using System;
using System.Collections.Generic;

namespace DTO
{
    public class FlightLog
    {
        public FlightLog()
        {
            Airports = new HashSet<Airport>();
        }

        public int FlightLogId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Airplane Airplane { get; set; }
        public ICollection<Airport> Airports { get; set; }
    }
}
