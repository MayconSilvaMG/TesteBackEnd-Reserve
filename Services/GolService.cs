using FlightSearchAPI.Models;
using FlightSearchAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightSearchAPI.Services
{
    public class GolService : IAirlineService
    {
        private readonly HttpClient _httpClient;

        public GolService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Flight>> GetFlightsAsync (string origin, string destination, DateTime date)
        {
            var url = $"https://dev.reserve.com.br/airapi/gol/getavailability?origin={origin}&destination={destination}&date={date:yyyy-MM-dd}";
            var response = await _httpClient.GetStringAsync(url);
            var flights = JsonSerializer.Deserialize<List<Flight>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return flights;
        }
    }
}
