using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Entities
{
    public class Satellite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temperature { get; set; }
        public int PlanetId { get; set; }
    }
}
