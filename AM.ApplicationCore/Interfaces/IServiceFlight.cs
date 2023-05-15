using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight: IService<Flight>
    {
        IEnumerable<DateTime> GetFlightDate(string destination);
        void GetFlight(String filterType, String filterValue);
        void showFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        Double DurationAverage(String destination);
        IEnumerable<Flight> OrderedDurationFlights();
        //  IEnumerable<Passenger> Seniortravellers(Flight flight);
        void Seniortravellers();

        //public void Add(Flight flight);
        //public void Remove(Flight flight);
        //public IList<Flight> GetAll();
    }
}
