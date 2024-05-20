using FlightSearchAPI.Models;
using FlightSearchAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightSearchAPI.Services
{
    public class LatamService : IAirlineService
    {
        private readonly HttpClient _httpClient;

        public LatamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Flight>> GetFlightsAsync(string origin, string destination, DateTime date)
        {
            var url = $"https://dev.reserve.com.br/airapi/latam/flights?departureCity={origin}&arrivalCity={destination}&departureDate={date:yyyy-MM-dd}";
            var response = await _httpClient.GetStringAsync(url);
            var flights = JsonSerializer.Deserialize<List<Flight>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return flights;
        }
    }
}
