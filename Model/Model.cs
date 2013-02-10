using System.Data.Entity;
using DTO;

namespace Model
{
    public class Model : DbContext
    {
        public Model(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public Model()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AirportConfiguration());
            modelBuilder.Configurations.Add(new AirplaneConfiguration());
            modelBuilder.Configurations.Add(new FlightLogConfiguration());
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<FlightLog> FlightLogs { get; set; }
    }
}
