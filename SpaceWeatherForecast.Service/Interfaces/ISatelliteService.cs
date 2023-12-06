using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Interfaces
{
    public interface ISatelliteService
    {
        List<SatelliteDTO> GetAll(int page, int size, decimal minTemprature, string? sort);
        SatelliteDTO GetById(int id);
        SatelliteDTO Add(SatelliteCreateDTO satellite);
        void Delete(int id);
        void Update(SatelliteUpdateDTO satellite);
        bool IsExist(int id);
        void Patch(int id, JsonPatchDocument<Satellite> patchDoc);
    }
}
