using System.Data.Entity.ModelConfiguration;
using DTO;

namespace Model
{
    public class FlightLogConfiguration
        : EntityTypeConfiguration<FlightLog>
    {
        public FlightLogConfiguration()
        {
            HasKey(e => e.FlightLogId);

            Property(e => e.LastUpdate);

            HasMany(r => r.Airports)
            .WithMany() // No navigation property here
            .Map(m =>
                {
                    m.MapLeftKey("FlightLogId");
                    m.MapRightKey("AirportId");
                    m.ToTable("BridgeTableForAirportsAndFlightlogs");
                });
        }
    }
}