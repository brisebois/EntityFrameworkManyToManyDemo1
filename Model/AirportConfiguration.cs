using System.Data.Entity.ModelConfiguration;
using DTO;

namespace Model
{
    public class AirportConfiguration
        : EntityTypeConfiguration<Airport>
    {
        public AirportConfiguration()
        {
            HasKey(e => e.AirportId);

            Property(e => e.Code)
                .IsRequired()
                .IsVariableLength()
                .IsUnicode(false);

            Property(e => e.Name)
                .IsRequired()
                .IsVariableLength()
                .IsUnicode(false);
        }
    }
}