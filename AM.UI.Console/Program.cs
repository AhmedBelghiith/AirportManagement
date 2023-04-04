// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

//Plane Plane1 = new Plane();
//Plane1.Capacity = 200;
//Plane1.ManuFactureDate = new DateTime(2023, 01, 31);
//Plane1.PlaneType = PlaneType.AirBus;
////Constructeur param
////Plane Plane2 = new Plane(PlaneType.Boing, 500, new DateTime(2022, 05, 23));
////init obj
//Plane Plane3 = new Plane
//               {
//                   Capacity = 3,
//                   ManuFactureDate = new DateTime(2023, 02, 01),
//                   PlaneType = PlaneType.Boing
//               };

//Passenger passenger1 = new Passenger
//{
//    FullName = new FullName { FirstName = "traveller4", LastName = "traveller4" },
//    EmailAdress = "test@esprit.tn"
//};
//Console.WriteLine(passenger1.CheckProfile("test", "test", "test@esprit.tn"));
//Traveller traveller1 = new Traveller
//{

//    FullName = new FullName { FirstName = "test2", LastName = "traveller4" },
//    Nationality = "Tunisian"
//};
//Console.WriteLine("traveller1: ");
//traveller1.PassengerType();
//Staff staff1 = new Staff
//{
//    FullName = new FullName { FirstName = "traveller4", LastName = "traveller4" },
//    Salary = 6000.0
//};
//Console.WriteLine("Staff1: ");
//staff1.PassengerType();


//ServiceFlight serviceFlight = new ServiceFlight();
//serviceFlight.Flights = TestData.listFlights;
//foreach (var item in serviceFlight.GetFlightDate("Paris"))
//{ 
//    Console.WriteLine(item);
//}
//serviceFlight.GetFlight("Destination", "Paris");

//serviceFlight.FlightDetailsDel(TestData.BoingPlane);

//Console.WriteLine("Number of flights: " + serviceFlight.ProgrammedFlightNumber(new DateTime(2022,02,01)));
//Console.WriteLine("Average of Flighs : " +
//    serviceFlight.DurationAverageDel("Madrid"));

//foreach (var i in serviceFlight.OrderedDurationFlights())
//{
//    Console.WriteLine(i);
//}

//serviceFlight.DestinationGroupedFlights();



//Passenger p1 = new Passenger
//{
//    FullName = new FullName { FirstName = "Ahmed", LastName = "Belghith" },
//    EmailAdress = "belghith.ahmed@esprit.tn"
//};
//Console.WriteLine(p1.ToString());
//p1.UpperFullName();
//Console.WriteLine(p1.ToString());

//instaciation 
AMContext ctx = new AMContext();

// ajout d'object aux DBSET
ctx.Flights.Add(TestData.flight1);

//persister les données
ctx.SaveChanges();

//affichage
Console.WriteLine(ctx.Flights.First().Plane.Capacity);



