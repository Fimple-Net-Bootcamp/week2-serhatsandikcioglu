using SpaceWeatherForecast.Data.DTO_s.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.DTO_s.Satellite
{
    public class SatelliteCreateDTO
    {
        public string Name { get; set; }
        public decimal Temperature { get; set; }
        public int PlanetId { get; set; }
    }
}
