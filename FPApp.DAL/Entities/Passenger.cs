using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPApp.DAL.Entities
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<FlightsPassenger> FlightsPass { get; set; }

        public Passenger()
        {
            FlightsPass = new List<FlightsPassenger>();
        }
    }
}
