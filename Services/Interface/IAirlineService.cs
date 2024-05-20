using FlightSearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchAPI.Services.Interface
{
    public interface IAirlineService
    {
        Task<List<Flight>> GetFlightsAsync(string origin, string destination, DateTime date);
    }
}
