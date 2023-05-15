using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {

        public List<Flight> Flights => GetAll().ToList();
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


        }
        //private readonly IGenericRepository<Flight> _repo;
        //public ServiceFlight(IGenericRepository<Flight> repo)
        //{
        //    _repo= repo;
        //}
        //public void Add(Flight flight)
        //{
        //    _repo.Add(flight);
        //}

        //public void Remove(Flight flight)
        //{
        //    _repo.Delete(flight);
        //}

        //public IList<Flight> GetAll()
        //{
        //  return (IList<Flight>)_repo.GetAll();
        //}

        public List<Flight> flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDate(string destination)
        {
            //List<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        result.Add(Flights[i].FlightDate);
            //    }
            //}
            //return result;
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        result.Add(flight.FlightDate);
            //    }
            //}
            //return result;

            //IEnumerable<DateTime> Query = (IEnumerable<DateTime>)(from f in Flights 
            //                              where f.Destination == destination 
            //                              select f);
            //return Query.ToList();
            IEnumerable<DateTime> queryLambda = Flights.Where(l => l.Destination == destination).Select(l => l.FlightDate);
               return queryLambda;
        }

        public void GetFlight(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;

                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;

                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }

                    }
                    break;
            }
        }

        public void showFlightDetails(Plane plane)
        {
            //var Query =
            //     from f in Flights
            //     where f.Plane == plane
            //     select new { f.FlightDate, f.Destination };
            //foreach (var f in Query)

            //{
            //    Console.WriteLine("Flight date:" + " " + f.FlightDate + " Flight destination" + " " + f.Destination);
            //}

            var QueryLambda = Flights.Where(f => (f.Plane == plane)).Select(f => f);  
            foreach (var f in QueryLambda)

            {
                Console.WriteLine("Flight date:" + " " + f.FlightDate + " Flight destination" + " " + f.Destination);
            };

        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //methode linQ
            //var req= from f in Flights
            //         where (f.FlightDate-startDate).TotalDays<=7
            //         && DateTime.Compare(f.FlightDate,startDate)>0
            //         select f;
            //return req.Count(); 
            //requete lambda
            var reqLambda= Flights.Where(f => ((f.FlightDate - startDate).TotalDays <= 7) && DateTime.Compare(f.FlightDate, startDate) > 0).Select(f => f).Count();
            return reqLambda;

        }

        public double DurationAverage(string destination)
        {

            //var req = from f in Flights
            //          where f.Destination.Equals(destination)
            //          select f.EstimatedDuration;

            var reqAverage = Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration);


            return reqAverage.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration
                      select f;

            var reqLambda= Flights.OrderBy(f=> f.EstimatedDuration).Select(f => f);
            return reqLambda;
        }

        //public IEnumerable<Passenger> Seniortravellers(Flight flight)
        //{
        //    //var req = from p in flight.Passengers.OfType<Traveller>()
        //    //          orderby p.BirthDate ascending
        //    //          select p;

        //    var reqLambda = flight.Passengers.OfType<Traveller>()
        //        .OrderBy(f => f.BirthDate).Select(f=>f);
        //    return reqLambda.Take(3);

        //}

        public void DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            var reqLambda = Flights.GroupBy(f => f.Destination);
            foreach (var g in reqLambda)
            {
                Console.WriteLine("Destination :" + g.Key);

                foreach (var f in g)
                { Console.WriteLine("Décolage:" + f.FlightDate); }
            }
        }

        public void Seniortravellers()
        {
            throw new NotImplementedException();
        }

      

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        //public ServiceFlight()
        //{
        //    FlightDetailsDel = plane=> {
        //        var Query =
        //        from f in Flights
        //             where f.Plane == plane
        //             select new { f.FlightDate, f.Destination };
        //        foreach (var f in Query)

        //        {
        //            Console.WriteLine("Flight date:" + " " + f.FlightDate + " Flight destination" + " " + f.Destination);
        //        }

        //    };
        //    DurationAverageDel = DurationAverage;
        //}
    }




}
