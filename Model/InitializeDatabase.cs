using System;
using System.Data.Entity;
using DTO;

namespace Model
{
    public class InitializeDatabase : CreateDatabaseIfNotExists<Model>
    {
        protected override void Seed(Model context)
        {
            var yul = new Airport
                {
                    Code = "YUL",
                    Name = "Montréal-Pierre Elliott " +
                            "Trudeau International Airport"
                };

            var cdg = new Airport
                {
                    Code = "CDG",
                    Name = "Charles de Gaulle " +
                            "International Airport"
                };

            var a = new Airplane
                {
                    TailNumber = "DC920",
                    Name = "A380"
                };

            var l = new FlightLog
                {
                    Airplane = a
                };

            l.Airports.Add(cdg);
            l.Airports.Add(yul);
            l.LastUpdate = DateTime.UtcNow;

            context.FlightLogs.Add(l);
            context.SaveChanges();
        }
    }
}