using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temprature { get; set; }
        public List<Satellite> Satellites { get; set; }
    }
}
