using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {

        public int flightId { get; set; }  //system genrated
        public string flightCode { get; set; }//system genrated
        public int aircraftId { get; set; }// from list
        public int pilotId { get; set; }//from list
        public string origin { get; set; } //user input
        public string destination { get; set; }//user input 
        public string departureDate { get; set; } // user input 

        public string departureTime { get; set; }//user input
        public decimal ticketPrice { get; set; }// user input
        public int vailableSeats { get; set; }//user input
        public string flightStatus { get; set; }//user input

        public   int  flightDuration{  get; set; }//user input








    }
}
