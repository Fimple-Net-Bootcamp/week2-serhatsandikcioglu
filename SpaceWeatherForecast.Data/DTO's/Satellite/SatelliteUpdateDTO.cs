using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.DTO_s.Satellite
{
    public class SatelliteUpdateDTO
    {
        [JsonIgnore]public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temprature { get; set; }
        public int PlanetId { get; set; }
    }
}
