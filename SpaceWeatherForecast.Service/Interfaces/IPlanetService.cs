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
        List<PlanetDTO> GetAll(int page, int size, decimal minTemprature, string? sort);
        PlanetDTO GetById(int id);
        PlanetDTO Add(PlanetCreateDTO planet);
        void Delete(int id);
        void Update(PlanetUpdateDTO planet);
        bool IsExist(int id);
        void Patch(int id, JsonPatchDocument<Planet> patchDoc);
    }
}
