using FlightManagementSystem.Models;
using Microsoft.Win32;
using System.Numerics;

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
            Console.WriteLine("Enter Full Name");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");

            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");

            string phone = Console.ReadLine();

            Console.Write("Enter Passport Number: ");
            string passport = Console.ReadLine();

            bool result = context.Passengers.Any(p => p.passportNumber == passport);
                          if (result == true)
            {
                Console.WriteLine("passport already exites ");
                return;
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

            Console.WriteLine("Passenger Registered Successfully");

            Console.WriteLine("Passenger ID:" +passengerId);

        }


        // 2 Add an Aircraft
        public static void AddAircraft()
        {

            Console.Write("Enter Aircraft Model ( Boeing 737, Airbus A320)   : ");

            string model = Console.ReadLine();

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

            Console.WriteLine("Aircraft Added Successfully");

            Console.WriteLine("Aircraft ID:" +aircraftId);


        }





        // 3 Register a Pilot
        public static void RegisterPilot()
        {

            Console.Write("Enter Pilot Name: ");

            string name = Console.ReadLine();

            Console.Write("Enter Pilot Phone: ");

            string phone = Console.ReadLine();

            Console.Write("Enter License Number: ");

            string license = Console.ReadLine();

            int pilotId = context.Pilots.Count + 1;

            Pilot pilot = new Pilot

            {

                pilotId = pilotId,

                pilotName = name,

                pilotPhone = phone,

                licenseNumber = license,

                flightHours = 0,

                isAvailable = true

            };

            context.Pilots.Add(pilot);

            Console.WriteLine("Pilot Registered Successfully");

            Console.WriteLine("Pilot ID:" +pilotId);

        }


        // 4 View All Flights
        public static void ViewAllFlight()
        {
            foreach( Flight  f in context.Flights )

            {
                Console.WriteLine("------------------------");

                Console.WriteLine("Flight Code :" +f.flightCode);

                Console.WriteLine("Origin: " +f.origin);

                Console.WriteLine("Destination:" +f.destination);

                Console.WriteLine("Departure Date:" + f.departureDate);

                Console.WriteLine($"Departure Time:" +f.departureTime);

                //Console.WriteLine("Available Seats:" +f.availableSeats);

                Console.WriteLine($"Ticket Price: " +f.ticketPrice);

                Console.WriteLine("Status: " + f.status);


            }



        }

        //5 Schedule a Flight
        public static void ScheduleFlight()


        {

            Console.WriteLine("____ScheduleFlight_______");
             var Aircrafts = context.Aircrafts.Where(f => f.isOperational).ToList();

            if(Aircrafts.Count == 0)

            {
                Console.WriteLine("No aviaable flight ");
            }

            Console.WriteLine(" enter aircraft id");
            int aircraftid=int.Parse(Console.ReadLine());

            var selectAircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftid);
            if (selectAircraft != null)
            {
                Console.WriteLine("invaild aircraft");

                return;

                 }

            var poilt= context.Pilots.Where(p => p.isAvailable).ToList();

            if (poilt.Count == 0)

            {
                Console.WriteLine("No poilt avaiable ");
            }

            Console.WriteLine(" enter apoilt id");
            int poiltId=int.Parse(Console.ReadLine());



            var selectpoilt = context.Pilots.FirstOrDefault(p => p.pilotId == poiltId);
            if (selectpoilt != null)
            {
                Console.WriteLine("invaild poilt");

                return;

            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Flight Recored");
            Console.WriteLine("------------------------");
            Console.WriteLine("Enter  flightId ");
            int flightID=int.Parse(Console.ReadLine());
            Console.WriteLine("flightCode");
            String flightCode=Console.ReadLine();
            Console.WriteLine(" Enter aircraftId");
            int aircraftID=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter origin ");
            string origin=Console.ReadLine();
            Console.WriteLine("Enter the  destination ");
            string destination=Console.ReadLine();
            Console.WriteLine("Enter the  destination ");
            Console.WriteLine(" Enter the departureDate ");
            string departureDate=Console.ReadLine();

            Console.WriteLine(" Enter   the departureTime ");
            string departureTime=Console.ReadLine();

            Console.WriteLine(" Enter  ticketPrice ");
            decimal ticketPrice=decimal.Parse(Console.ReadLine());



            //context.Flights.Add(new Flight
            //{
            //   flightId  = flightid, 
            //    patientId = patientId,         
            //    doctorId = doctorId,         
            //    slotId = slotId,             
            //    appointmentDate = selectedSlot.slotDate, 
            //    appointmentTime = selectedSlot.slotTime,  
            //    status = "Scheduled"             
            //});








        }







        static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {

                Console.WriteLine(" =======================================");
                Console.WriteLine("FLIGHT MANAGEMENT SYSTEM ");
                Console.WriteLine(" =======================================");
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
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 0:

                        exit=true;
                        break;



                }//switch

                Console.WriteLine(" Enter any key");
                Console.ReadKey();
                Console.Clear();

            }//while



           
            































































































                }
    }
}
}
