using System;
using System.Collections.Generic;

namespace FPApp.Client.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public DateTime FlightTime { get; set; }
        public List<PassengerInfoViewModel> passengerInfos { get; set; }
    }
}