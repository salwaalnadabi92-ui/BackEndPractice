using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
    {

        public int bookingId { get; set; }  //system generated
        public int passengerId { get; set; }// from the list
        public int flightId { get; set; }//from the list
        public string seatNumber { get; set; }//system genrated 
        public string bookingDate { get; set; }//system genrated
        public decimal totalPrice { get; set; }// from flight.ticket price
        public string  bookingStatus { get; set; }//defualt value
        

                                                                                                                                                                                                                              










    }
}
