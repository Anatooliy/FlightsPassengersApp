using FPApp.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FPApp.DAL.Configuration
{
    class CityConfig : EntityTypeConfiguration<City>
    {
        public CityConfig()
        {
            Property(p => p.CityName)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(p => p.FlightFrom)
                .WithRequired(p => p.CityFrom)
                .HasForeignKey(p => p.CityFromId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.FlightTo)
                .WithRequired(p => p.CityTo)
                .HasForeignKey(p => p.CityToId)
                .WillCascadeOnDelete(false);
        }
    }
}
