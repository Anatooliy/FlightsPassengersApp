using System;
using System.Collections.Generic;

namespace FPApp.Service.Models
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public DateTime FlightTime { get; set; }
        public List<PassengerInfoDTO> passengerInfos { get; set; }
    }
}