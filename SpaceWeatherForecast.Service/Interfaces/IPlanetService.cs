using Microsoft.AspNetCore.JsonPatch;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Interfaces
{
    public interface IPlanetService
    {
        List<Planet> GetAll(bool relational);
        Planet GetById(int id);
        Planet Add(PlanetCreateDTO planet);
        void Delete(int id);
        public void Update(PlanetUpdateDTO planet);
        public bool IsExist(int id);
        public void Patch(int id, JsonPatchDocument<Planet> patchDoc);
    }
}
