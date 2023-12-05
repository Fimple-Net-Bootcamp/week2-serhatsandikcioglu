using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Service.Interfaces;
using SpaceWeatherForecast.Service.Services;
using System.Drawing;
using System.Numerics;
using System.Xml.Serialization;

namespace SpaceWeatherForecast.Controllers
{
    [Route("api/v1/satellites/[action]")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {
        private readonly ISatelliteService _satelliteService;

        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, int size = 10, decimal minTemprature = 0, string? sort = "", string? sortType = "")
        {
            List<Satellite> satellites = _satelliteService.GetAll(page, size, minTemprature, sort, sortType);
            return Ok(satellites);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            bool satelliteIsExist = _satelliteService.IsExist(id);
            if (satelliteIsExist)
            {
                Satellite satellite = _satelliteService.GetById(id);
                return Ok(satellite);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(SatelliteCreateDTO satelliteCreateDTO)
        {
            SatelliteDTO createdSatellite = _satelliteService.Add(satelliteCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdSatellite.Id }, createdSatellite);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,SatelliteUpdateDTO satelliteUpdateDTO)
        {
            bool satelliteIsExist = _satelliteService.IsExist(id);
            if (satelliteIsExist)
            {
                satelliteUpdateDTO.Id = id;
                _satelliteService.Update(satelliteUpdateDTO);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool satelliteIsExist = _satelliteService.IsExist(id);
            if (satelliteIsExist)
            {
                _satelliteService.Delete(id);
                return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Satellite> patchDoc)
        {
            bool satelliteIsExist = _satelliteService.IsExist(id);
            if (satelliteIsExist)
            {
                _satelliteService.Patch(id, patchDoc);
                return Ok();
            }
            return NotFound();
        }
    }
}
