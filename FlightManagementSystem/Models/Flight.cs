using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {

        public int flightId { get; set; }  
        public string flightCode { get; set; }
        public int aircraftId { get; set; }
        public int pilotId { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string departureDate { get; set; }

        public string departureTime { get; set; }
        public decimal ticketPrice { get; set; }
        public int vailableSeats { get; set; }
        public string flightStatus { get; set; }

        public   int  flightDuration{  get; set; }








    }
}
