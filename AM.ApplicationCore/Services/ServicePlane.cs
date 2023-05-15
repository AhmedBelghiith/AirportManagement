using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using System.Collections.Generic;
using AM.Infrastructure;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
   

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


        }

        public void DeletePlanes()
        {
            //Delete(p=>p.ManufactureDate.AddYears(10).Year < DateTime.Now.Year);
            Delete(p => DateTime.Now.Year - p.ManuFactureDate.Year > 10);
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll()
                            .OrderByDescending(p => p.PlaneId)
                            .Take(n)
                            .SelectMany(p => p.Flights)
                            .OrderBy(f => f.FlightDate)
                            .ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {

            return GetById(p.PlaneKey).Flights.
                SelectMany(f => f.Tickets).
                Select(p => p.Passenger).
                ToList();
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
            var capacity = flight.Plane.Capacity;
            var nbTicket = flight.Tickets.Count();
            return capacity > nbTicket;
        }
    }
}
