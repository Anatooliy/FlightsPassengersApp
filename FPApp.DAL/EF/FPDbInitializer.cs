using FPApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPApp.DAL.EF
{
    class FPDbInitializer : DropCreateDatabaseAlways<FPContext>
    {
        protected override void Seed(FPContext db)
        {
            City cityDnipro = new City { CityName = "Dnipro" };
            City cityKyiv = new City { CityName = "Kyiv" };
            City cityLviv = new City { CityName = "Lviv" };
            City cityKharkiv = new City { CityName = "Kharkiv" };

            Flight LvivDnipro = new Flight {
                CityFrom = cityLviv,
                CityTo = cityDnipro,
                FlightTime = new DateTime(2019, 11, 15, 11, 15, 0)
            };

            Flight KharkivLviv = new Flight
            {
                CityFrom = cityKharkiv,
                CityTo = cityLviv,
                FlightTime = new DateTime(2019, 12, 2, 0, 30, 0)
            };

            Flight DniproKharkiv = new Flight
            {
                CityFrom = cityDnipro,
                CityTo = cityKharkiv,
                FlightTime = new DateTime(2020, 01, 5, 15, 0, 0)
            };

            Flight DniproKyiv = new Flight
            {
                CityFrom = cityDnipro,
                CityTo = cityKyiv,
                FlightTime = new DateTime(2020, 11, 11, 7, 0, 0)
            };

            Passenger passenger1 = new Passenger { FirstName = "Johnny", LastName = "Depp" };
            Passenger passenger2 = new Passenger { FirstName = "Ryan", LastName = "Reynolds" };
            Passenger passenger3 = new Passenger { FirstName = "Margot", LastName = "Robbie" };
            Passenger passenger4 = new Passenger { FirstName = "Will", LastName = "Smith" };
            Passenger passenger5 = new Passenger { FirstName = "Matthew", LastName = "McConaughey" };
            Passenger passenger6 = new Passenger { FirstName = "Scarlett", LastName = "Johansson" };
            Passenger passenger7 = new Passenger { FirstName = "Jennifer", LastName = "Lawrence" };
            Passenger passenger8 = new Passenger { FirstName = "Jared", LastName = "Leto" };
            Passenger passenger9 = new Passenger { FirstName = "Brad", LastName = "Pitt" };
            Passenger passenger10 = new Passenger { FirstName = "Matt", LastName = "Damon" };
            Passenger passenger11 = new Passenger { FirstName = "Tom", LastName = "Hardy" };
            Passenger passenger12 = new Passenger { FirstName = "Emma", LastName = "Stone" };
            Passenger passenger13 = new Passenger { FirstName = "Nicolas", LastName = "Cage" };
            Passenger passenger14 = new Passenger { FirstName = "Gal", LastName = "Gadot" };
            Passenger passenger15 = new Passenger { FirstName = "Tom", LastName = "Hanks" };



            db.Cities.AddRange(new List<City> { cityDnipro, cityKyiv, cityLviv, cityKharkiv });
            db.Flights.AddRange(new List<Flight> { LvivDnipro, KharkivLviv, DniproKharkiv, DniproKyiv });
            db.Passengers.AddRange(new List<Passenger> {
                passenger1,
                passenger2,
                passenger3,
                passenger4,
                passenger5,
                passenger6,
                passenger7,
                passenger8,
                passenger9,
                passenger10,
                passenger11,
                passenger12,
                passenger13,
                passenger14,
                passenger15
            });

            db.FlightsPassengers.AddRange(new List<FlightsPassenger> {
                new FlightsPassenger { Flight = LvivDnipro, Passenger = passenger1, IsCheckedIn = true },
                new FlightsPassenger { Flight = LvivDnipro, Passenger = passenger2},
                new FlightsPassenger { Flight = KharkivLviv, Passenger = passenger3},
                new FlightsPassenger { Flight = KharkivLviv, Passenger = passenger4, IsCheckedIn = true },
                new FlightsPassenger { Flight = KharkivLviv, Passenger = passenger5},
                new FlightsPassenger { Flight = DniproKharkiv, Passenger = passenger6, IsCheckedIn = true },
                new FlightsPassenger { Flight = DniproKharkiv, Passenger = passenger7, IsCheckedIn = true },
                new FlightsPassenger { Flight = DniproKharkiv, Passenger = passenger8},
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger9},
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger10},
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger11},
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger12, IsCheckedIn = true },
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger13},
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger14, IsCheckedIn = true },
                new FlightsPassenger { Flight = DniproKyiv, Passenger = passenger15}
            });

            base.Seed(db);
        }
    }
}
