using FlightSearchAPI.Models;
using FlightSearchAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IAirlineService[] _airlineServices;

        public FlightsController(IAirlineService[] airlineServices)
        {
            _airlineServices = airlineServices;
        }

        [HttpGet("disponibilidade")]
        public async Task<IActionResult> GetFlights([FromQuery] string origem, [FromQuery] string destino, [FromQuery]DateTime data)
        {
            var allFlights = new List<Flight>();

            foreach(var service in _airlineServices)
            {
                var flights = await service.GetFlightsAsync(origem, destino, data);
                allFlights.AddRange(flights);
            }

            var sortedFlights = allFlights.OrderBy(f => f.Tarifa).ThenBy(f => f.Partida).ToList();

            return Ok(sortedFlights);
        }
    }
}
