using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearchAPI.Models
{
    public class Flight
    {
        public string Voo { get; set; }
        public string Companhia { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Partida { get; set; }
        public DateTime Chegada { get; set; }
        public decimal Tarifa { get; set; }
    }
}
