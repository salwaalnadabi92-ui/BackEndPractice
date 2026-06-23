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

        // Register a Passenger
        public static void RegisterPassenger()
        {
            Console.WriteLine("Enter passenger name");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");

            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");

            string phone = Console.ReadLine();

            Console.Write("Enter Passport Number: ");

            string passport = Console.ReadLine();

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

            Console.WriteLine("Passenger ID: {passengerId}");

        }


        // Add an Aircraft
        public static void AddAircraft()
        {

            Console.Write("Enter Aircraft Model: ");

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

            Console.WriteLine($"Aircraft ID: {aircraftId}");


        }





        // Register a Pilot





        // View All Flights



        static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {

                Console.WriteLine(" =======================================");
                Console.WriteLine("FLIGHT MANAGEMENT SYSTEM ");
                Console.WriteLine(" =======================================");
                Console.WriteLine("1.Register a Passenger ");
                Console.WriteLine("2. Add an Aircraft ");
                Console.WriteLine("3.Register a Pilot");
                Console.WriteLine("4.View All Flights ");
                Console.WriteLine("5. Schedule a Flight ");
                Console.WriteLine("6.Book a Flight");
                Console.WriteLine("7.Cancel a Booking ");
                Console.WriteLine("8.Depart a Flight");
                Console.WriteLine("9.Cancel a Flight");
                Console.WriteLine("10.Passenger Booking History");
                Console.WriteLine("11. Flight Revenue & Load Factor Report");
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
                        break;

                    case 3:
                        break;


                    case 4:
                        break;

                    case 5:
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
            }//while




































































































                }
    }
}
