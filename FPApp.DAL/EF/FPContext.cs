namespace FPApp.DAL.EF
{
    using FPApp.DAL.Configuration;
    using FPApp.DAL.Entities;    
    using System.Data.Entity;    

    public class FPContext : DbContext
    {
        static FPContext()
        {
            Database.SetInitializer(new FPDbInitializer());
        }

        public FPContext()
            : base("name=FPDBContext")
        {            
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<FlightsPassenger> FlightsPassengers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new FlightConfig());
            modelBuilder.Configurations.Add(new PassengerConfig());
            modelBuilder.Configurations.Add(new FlightsPassengerConfig());
        }
    }
}