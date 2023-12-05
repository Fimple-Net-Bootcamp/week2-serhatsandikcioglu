using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;

namespace SpaceWeatherForecast.Data.DTO_s.Planet
{
    public class PlanetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temprature { get; set; }
        public List<SatelliteDTO>? Satellites { get; set; }
    }
}
