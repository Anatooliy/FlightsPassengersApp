using FPApp.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FPApp.DAL.Configuration
{
    class FlightConfig : EntityTypeConfiguration<Flight>
    {
        public FlightConfig()
        {
            Property(p => p.FlightTime).IsRequired();
        }
    }
}
