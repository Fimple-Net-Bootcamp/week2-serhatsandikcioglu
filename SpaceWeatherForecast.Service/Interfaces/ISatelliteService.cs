using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Interfaces
{
    public interface ISatelliteService
    {
        List<Satellite> GetAll();
        Satellite GetById(int id);
        void Add(SatelliteCreateDTO satellite);
        void Delete(int id);
        void Update(SatelliteUpdateDTO satellite);
    }
}
