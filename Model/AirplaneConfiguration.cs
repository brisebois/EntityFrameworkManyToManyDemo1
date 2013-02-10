using System.Data.Entity.ModelConfiguration;
using DTO;

namespace Model
{
    public class AirplaneConfiguration
        : EntityTypeConfiguration<Airplane>
    {
        public AirplaneConfiguration()
        {
            HasKey(e => e.AirplaneId);

            Property(e => e.TailNumber)
                .IsRequired()
                .IsVariableLength()
                .IsUnicode(false);

            Property(e => e.Name)
                .IsRequired()
                .IsVariableLength()
                .IsUnicode(false);

            HasMany(e => e.FlightLogs)
                .WithRequired(e => e.Airplane)
                .WillCascadeOnDelete(true);
        }
    }
}