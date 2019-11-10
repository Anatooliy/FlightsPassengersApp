using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace FPApp.DAL.Entities
{
    public class City
    {        
        public int CityId { get; set; }
        public string CityName { get; set; }
        
        public virtual ICollection<Flight> FlightTo { get; set; }        
        public virtual ICollection<Flight> FlightFrom { get; set; }

        public City()
        {
            FlightTo = new List<Flight>();
            FlightFrom = new List<Flight>();
        }
    }
}
