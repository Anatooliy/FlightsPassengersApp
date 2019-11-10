using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPApp.DAL.Entities
{
    public class FlightsPassenger
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public bool IsCheckedIn { get; set; } = false;

        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }        
    }
}
