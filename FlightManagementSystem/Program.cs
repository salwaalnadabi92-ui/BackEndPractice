using FlightManagementSystem.Models;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace FlightManagementSystem
{
    internal class Program
    {
        public static FlightContext context = new FlightContext
        {

            Passengers = new List<Passenger>(),
              Pilots   = new  List <Pilot>(),
              Aircrafts =  new  List<Aircraft>() ,
              Flights   =new   List<Flight>(),
              Bookings = new List<Booking>(),



    };

        //1 Register a Passenger
        public static void RegisterPassenger()
        {

            Console.WriteLine("Add New Passenger");
            Console.WriteLine("______________________");
            Console.WriteLine("Enter Full Name");
            string name = Console.ReadLine();
            while (name=="")

            {
                Console.Write("Invalid name. Enter again: ");

                name = Console.ReadLine();

            }



            Console.Write("Enter Email: ");

            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");

            string phone = Console.ReadLine();

            Console.Write("Enter Passport Number: ");
            string passport = Console.ReadLine();
            while (context.Passengers.Any(p => p.passportNumber == passport))

            {

                Console.Write("Passport already exists. Enter another one: ");

                passport = Console.ReadLine();


            }

            Console.Write("Enter Nationality: ");

            string nationality = Console.ReadLine();

            int passengerId = context.Passengers.Count + 1;

            Passenger passenger = new Passenger

            {

                passengerId = passengerId,

                passengerName = name,

                passengerEmail = email,

                passengerPhone = phone,

                passportNumber = passport,

                nationality = nationality

            };

            context.Passengers.Add(passenger);


            Console.WriteLine("____________________________________");
            Console.WriteLine("Passenger Registered Successfully");
            Console.WriteLine("Passenger ID:" +passengerId);
            Console.WriteLine("____________________________________");
        }

        // 2 Add an Aircraft
        public static void AddAircraft()
        {

            Console.Write("Enter Aircraft Model ( Boeing 737, Airbus A320)   : ");

            string model = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(model))

                    {

                 Console.Write("Invalid model. Enter again: ");

                    model = Console.ReadLine();

                            }

            Console.Write("Enter Total Seats: ");

            int totalSeats = Convert.ToInt32(Console.ReadLine());

            int aircraftId = context.Aircrafts.Count + 1;


            Aircraft aircraft = new Aircraft

            {
                aircraftId = aircraftId,

                model = model,

                totalSeats = totalSeats,

                isOperational = true

            };

            context.Aircrafts.Add(aircraft);

            Console.WriteLine("_____________________________");
            Console.WriteLine("Aircraft Added Successfully");
            Console.WriteLine("Aircraft ID: " +aircraftId);
            Console.WriteLine("_____________________________");

        }


        // 3 Register a Pilot
        public static void RegisterPilot()
        {

            Console.Write("Enter Pilot Name: ");//aske user to enter name

            string name = Console.ReadLine();

            while (name == "")//vailate name

            {
                Console.Write("Invalid name. Enter again: ");

                name = Console.ReadLine();
            }

                Console.Write("Enter Pilot Phone: ");//ask user to enter phoe

            string phone = Console.ReadLine();

            Console.Write("Enter License Number: ");//ask user to enter licence

            string license = Console.ReadLine();


            while (context.Pilots.Any(p => p.licenseNumber == license))//vailate licence number

            {

                Console.Write("License already exists. Enter another one: ");

                license = Console.ReadLine();

            }

            int pilotID = context.Pilots.Count + 1;//auto genrated pilot id


            Pilot pilot = new Pilot//add pilot

            {

                pilotId = pilotID,

                pilotName = name,

                pilotPhone = phone,

                licenseNumber = license,

                flightHours = 0,

                isAvailable = true

            };

            context.Pilots.Add(pilot);

            Console.WriteLine("________________________________");
            Console.WriteLine("Pilot Registered Successfully");
            Console.WriteLine("Pilot ID:" +pilotID);
            Console.WriteLine("________________________________");
        }


        // 4 View All Flights
        public static void ViewAllFlight()
        {

            if (context.Flights.Count == 0)

            {
                Console.WriteLine(" No available flight");
            }


            foreach (var f in context.Flights)

            {
                Console.WriteLine("------------------------");

                Console.WriteLine("Flight Code :" +f.flightCode);

                Console.WriteLine("Origin: " +f.origin);

                Console.WriteLine("Destination:" +f.destination);

                Console.WriteLine("Departure Date:" + f.departureDate);

                Console.WriteLine($"Departure Time:" +f.departureTime);

                Console.WriteLine("Available Seats:" + f.vailableSeats);

                Console.WriteLine($"Ticket Price: " +f.ticketPrice);

                Console.WriteLine("Status: " + f.flightStatus);


            }



        }

        //5 Schedule a Flight
        public static void ScheduleFlight()


        {
            Console.WriteLine("__________________________");
            Console.WriteLine("____ScheduleFlight_______");

             var Aircrafts = context.Aircrafts.Where(f => f.isOperational).ToList();//find flight which is operational

            if(Aircrafts.Count == 0)
            {
                Console.WriteLine("No aviaable aircraft");
            }

            Console.WriteLine(" avialable aircraft");//display aircrafts 
            foreach ( var aircraft in Aircrafts )

            {
                Console.WriteLine("ID : "  +aircraft.aircraftId   + "model:"   + aircraft.model +   "totalSeats: "+ aircraft.totalSeats);

            }

            Console.WriteLine("Enter aircraft id");//ask user to enter id
            int aircraftid=int.Parse(Console.ReadLine());

            var selectAircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftid);//find the id 

            if (selectAircraft == null)
            {
                Console.WriteLine("invaild aircraft");

                return;

                 }

            var poilt= context.Pilots.Where(p => p.isAvailable).ToList();//find the pilot

            if (poilt.Count == 0)

            {
                Console.WriteLine("No poilt avaiable ");
                return;
            }

            //forece miss

            Console.WriteLine(" Enter apoilt id");//ask user to choose  pilot from the list
            int poiltId=int.Parse(Console.ReadLine());
            while (!context.Pilots.Any(p => p.pilotId == poiltId && p.isAvailable))//vaildate

            {

                Console.Write("Pilot unavailable. Enter again: ");

                poiltId = int.Parse(Console.ReadLine());

            }

            var selectpoilt = context.Pilots.FirstOrDefault(p => p.pilotId == poiltId);//find the choose pilot
            if (selectpoilt == null)
            {
                Console.WriteLine("invaild poilt");

                return;
            }

            Console.WriteLine("Enter Origin:");//ask user to enter origin
            string origin = Console.ReadLine();

            Console.WriteLine("Enter Destination:");//ask user to enter the destation

            string destination = Console.ReadLine();

            while (origin == destination)//vailate 

            {
                Console.WriteLine("Origin and destination cannot be the same.");

                Console.Write("Destination: ");

                destination = Console.ReadLine();
            }

            Console.WriteLine("Enter Departure Date (yyyy-MM-dd):");//aske user to enter date

            String departureDate =(Console.ReadLine());

            Console.WriteLine("Enter Departure Time:");//ask user to input time

            string departureTime = Console.ReadLine();

            Console.WriteLine("Enter Ticket Price:");//ask user to input price

            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            string flightCode = "OA-" + (context.Flights.Count() + 1);//auto genrated flight code
             //miss id

            Console.WriteLine("------------------------");
            Console.WriteLine("Flight Recored");
            Console.WriteLine("------------------------");

            Flight flight = new Flight//add flight

            {
                flightCode = flightCode,

                aircraftId = selectAircraft.aircraftId,

                pilotId = selectpoilt.pilotId,

                origin = origin,

                destination = destination,

                departureDate = departureDate,

                departureTime = departureTime,

                vailableSeats = selectAircraft.totalSeats,

                ticketPrice = ticketPrice,

                flightStatus = "Scheduled"

            };

            context.Flights.Add(flight);


            Console.WriteLine("_________________________________________");
            Console.WriteLine("Flight Scheduled Successfully");
            Console.WriteLine("Flight Code:" +flight.flightCode);
            Console.WriteLine("Available Seats:" +flight.vailableSeats);
            Console.WriteLine("Status: "+flight.flightStatus);
            Console.WriteLine("_________________________________________");

        }

        //6 book flight 

        public static void BookFlight()
        {
            Console.WriteLine(" Enetr passenger id");//ask user enter id
            int id = int.Parse(Console.ReadLine());

            while (!context.Passengers.Any(p => p.passengerId == id))//vaildate 

            {

                Console.Write("Passenger not found. Enter again: ");

                id= int.Parse(Console.ReadLine());

            }

            var selectpassenger = context.Passengers.FirstOrDefault(p => p.passengerId == id);//find the user from the table(passenger)

            if (selectpassenger == null)
            {
                Console.WriteLine(" passenger not found");
                return;
            }

            Console.WriteLine(" Enter destination");//assinge the destation
            string destination = Console.ReadLine();

            var selectedflightS = context.Flights.Where(f => f.destination == destination &&//show just  appropriate flight same destation & status=Scheduled & exit seat
                       f.flightStatus == "Scheduled" &&
                       f.vailableSeats != 0).ToList();

            if (selectedflightS.Count == 0)
            {
                Console.WriteLine("No available flights.");

                return;
            }

            

            foreach (var f in selectedflightS)//display flight
            {
                Console.WriteLine("id:" + f.flightId +
                    " destination:" + f.destination +
                    " origin " + f.origin +
                    " departureTime" + f.departureTime +
                    " departureDate " + f.departureDate +
                    "  ticketPric" + f.ticketPrice);
            }

            Console.WriteLine("ENTER FLIGHT ID");//ask user to enter the flight
            int  flightID = int.Parse(Console.ReadLine());
            while (!context.Flights.Any(f => f.flightId == flightID))

            {

                Console.Write("Flight not found. Enter again: ");

                flightID = int.Parse(Console.ReadLine());

            }

            var selectedFlight = context.Flights.FirstOrDefault(f => f.flightId == flightID);//find the flight

            if (selectedFlight == null)

            {
                Console.WriteLine("Invalid Flight.");

                return;

            }
            Console.WriteLine("Enter seat number");//ask user to enter seat number
            string seatLabel=Console.ReadLine();


            int bookid = context.Bookings.Count + 1;//assinge booking id


            Booking booking = new Booking//add booking 

            {

                bookingId = bookid,

                passengerId = selectpassenger.passengerId,

                flightId = selectedFlight.flightId,

                seatNumber = seatLabel,

                totalPrice = selectedFlight.ticketPrice,

              bookingStatus = "Confirmed"

            };

            context.Bookings.Add(booking);

            selectedFlight.vailableSeats--;//decrement the seat number

            Console.WriteLine("___________________________________");
            Console.WriteLine("Booking Created Successfully");
            Console.WriteLine("Seat Number: " + seatLabel);
            Console.WriteLine("Total Price:" + booking.totalPrice);
            Console.WriteLine("______________________________________");
        }



        // 7 cancel a booking
        public static void CancelBooking()
        {

            Console.WriteLine("Enter booking id");//request the booking id
            int bookId = int.Parse(Console.ReadLine());

            var checkid = context.Bookings.FirstOrDefault(b => b.bookingId == bookId);//find the booking 

            if (checkid == null)
            {
                Console.WriteLine(" booking id not found");
            }

            Console.WriteLine(" Enter flight id");
            int flightID = int.Parse(Console.ReadLine());

            var checkFlight = context.Bookings.FirstOrDefault(fl => fl.flightId == flightID);//find the flight which related with same booking

            if (checkFlight != null)//change stauts to cancelled
            {

                checkid.bookingStatus = "cancelled";

                //--
            }

            Console.WriteLine("_____________________________");
            Console.WriteLine(" booking cancel succussfuly");
            Console.WriteLine("_____________________________");

        }

        //8 Depart Flight

        public static void DepartFlight()
        {

   
            Console.WriteLine("Enter Flight ID:");//ask user to enter number of flight

            int flightId = int.Parse(Console.ReadLine());

            var flight = context.Flights .FirstOrDefault(f => f.flightId == flightId);//find the flight 

            if (flight == null)

            {
                Console.WriteLine("Flight not found!");//ensure the flight is found

                return;

            }

            if (flight.flightStatus == "Departed")//ensure the flight is not departed

            {

                Console.WriteLine("Flight already departed");

                return;

            }

            if (flight.flightStatus == "Cancelled")//ensure the flight is not cancelled

            {

                Console.WriteLine("Cancelled flight cannot departed");

                return;

            }

            flight.flightStatus = "Departed";//change the flight to departed
            //poilt.avilv//miss

            var pilot = context.Pilots .FirstOrDefault(p => p.pilotId == flight.pilotId);//find the pilot which related to the flight

            if (pilot != null)

            {
                Console.WriteLine("Enter Flight Duration (hours):");//assign pilot total flight hour

                int duration = int.Parse(Console.ReadLine());

                pilot.flightHours += duration;

            }
            Console.WriteLine("_____________________________-");//system confirms the departur
            Console.WriteLine("Flight departed successfully.");
            Console.WriteLine("_____________________________-");
        }

        // 9 cencel flight 

        public static void CencelFlight()
        {
            Console.WriteLine(" Eenter flight id");//find flight want to cencel
            int flightId=int.Parse(Console.ReadLine());

            var selectflight=context.Flights .FirstOrDefault(f=>f.flightId == flightId);

            if(selectflight == null) 
            
            { 
            Console.WriteLine(" flight not found");
            }

              selectflight.flightStatus = "Cancelled";//change status to cancelled


            var selectBooking=context.Bookings.Where(b=>b.flightId == flightId).ToList();//find all booking that related to the flight

            int  numberBooking=selectBooking.Count;//count them

            foreach (var booking in selectBooking)//show and make all cencell

            {
              booking.bookingStatus = "Cancelled";


            }

            var selectPoilt=context.Pilots.FirstOrDefault(p=>p.pilotId==selectflight.pilotId);//make pilot avialabale 

            if(selectPoilt !=null)
            {
                selectPoilt.isAvailable = true;

            }
            Console.WriteLine("________________________________");
            Console.WriteLine(" flight cencal succussfuly");
            Console.WriteLine("Booking affected:" + numberBooking);//show all booking affected
            Console.WriteLine("----------------------------------");
        }

        //10 passenger booking history

        public static void PassengerBookingHistory()
        {
            Console.WriteLine("Enter passenger id ");
            int passId=int.Parse(Console.ReadLine());

            var searchPassenger=context.Passengers.FirstOrDefault(p=>p.passengerId == passId);//find the passenger
        

            if(searchPassenger == null)
            {
                Console.WriteLine("passenger not found");

            }

            var findBooking = context.Bookings.Where(b => b.passengerId==passId  && //find all booking which stauta is confirmed for the passenger
            b.bookingStatus=="confirmed").ToList();


           if( findBooking.Count==0)

            {
                Console.WriteLine("no confirm booking found ");
                return;
            }


            decimal totalAmount = 0;

            foreach (var booking in findBooking)
            {
                var flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Flight Code: " +flight.flightCode);
                Console.WriteLine("Origin:"+flight.origin);
                Console.WriteLine("Destination:" +flight.destination);
                Console.WriteLine("Departure Date:"+flight.departureDate);
                Console.WriteLine("Seat Number:"+booking.seatNumber);
                Console.WriteLine("Price Paid: "+booking.totalPrice);
                Console.WriteLine("Status: " +booking.bookingStatus);
                Console.WriteLine("--------------------------------");

                totalAmount += booking.totalPrice;//calculate  total price 
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Total Amount Paid: {totalAmount}");
            Console.WriteLine("--------------------------------");

        }

        

        //11 flight revenue & load favtor report


        //public static void flightRevenue()
        //{



        //}

        //    var flight = context.Bookings.Where(b => b.flightId==flightid);



















        static void Main(string[] args)
                {


                    bool exit = false;

                    while (exit == false)
                    {

                        Console.WriteLine("========================================");
                        Console.WriteLine("FLIGHT MANAGEMENT SYSTEM ");
                        Console.WriteLine("========================================");
                        Console.WriteLine("1.Register a Passenger ");
                        Console.WriteLine("2.Add an Aircraft ");
                        Console.WriteLine("3.Register a Pilot");
                        Console.WriteLine("4.View All Flights ");
                        Console.WriteLine("5.Schedule a Flight ");
                        Console.WriteLine("6.Book a Flight");
                        Console.WriteLine("7.Cancel a Booking ");
                        Console.WriteLine("8.Depart a Flight");
                        Console.WriteLine("9.Cancel a Flight");
                        Console.WriteLine("10.Passenger Booking History");
                        Console.WriteLine("11.Flight Revenue & Load Factor Report");
                        Console.WriteLine("0.Exit");
                        Console.WriteLine("========================================");
                        Console.WriteLine("  Enter your choose");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {

                            case 1:

                                RegisterPassenger();
                                break;

                            case 2:
                                AddAircraft();
                                break;

                            case 3:
                                RegisterPilot();
                                break;


                            case 4:
                                ViewAllFlight();

                                break;

                            case 5:
                                ScheduleFlight();
                                break;

                            case 6:
                                BookFlight();

                                break;

                            case 7:
                                CancelBooking();
                                break;

                            case 8:
                                DepartFlight();

                                break;

                            case 9:
                                CencelFlight();

                                break;

                            case 10:

                        PassengerBookingHistory();
                                break;

                            case 11:

                        //flightRevenue();
                                break;

                            case 0:

                                exit = true;
                                break;



                        }//switch

                        Console.WriteLine(" Enter any key");
                        Console.ReadKey();
                        Console.Clear();

                    }//while



































































































                
            
        
}
}
}


