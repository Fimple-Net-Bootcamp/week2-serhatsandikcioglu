using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.DTO_s.Satellite
{
    public class SatelliteUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temperature { get; set; }
    }
}
