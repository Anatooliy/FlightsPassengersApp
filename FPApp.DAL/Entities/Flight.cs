using System;
using System.Collections.Generic;

namespace FPApp.DAL.Entities
{
    public class Flight
    {        
        public int FlightId { get; set; }
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public DateTime FlightTime { get; set; }

        public virtual City CityFrom { get; set; }        
        public virtual City CityTo { get; set; }

        public virtual ICollection<FlightsPassenger> FlightsPass { get; set; }

        public Flight()
        {
            FlightsPass = new List<FlightsPassenger>();
        }     
    }
}
