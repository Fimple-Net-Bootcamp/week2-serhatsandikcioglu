using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Interfaces
{
    public interface ISatelliteRepository
    {
        List<Satellite> GetAll(int page, int size, decimal minTemprature, string? sort);
        Satellite GetById(int id);
        void Add(Satellite satellite);
        void Delete(int id);
        void Update(Satellite satellite);
        bool IsExist(int id);
    }
}
