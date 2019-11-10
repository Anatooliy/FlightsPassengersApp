using FPApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPApp.DAL.Configuration
{
    class PassengerConfig : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfig()
        {
            Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            Property(p => p.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
