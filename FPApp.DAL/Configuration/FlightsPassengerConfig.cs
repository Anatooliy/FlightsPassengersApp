using FPApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPApp.DAL.Configuration
{
    class FlightsPassengerConfig : EntityTypeConfiguration<FlightsPassenger>
    {
        public FlightsPassengerConfig()
        {
            HasKey(fp => new { fp.FlightId, fp.PassengerId });
            Property(p => p.IsCheckedIn).IsRequired();
        }
    }
}
