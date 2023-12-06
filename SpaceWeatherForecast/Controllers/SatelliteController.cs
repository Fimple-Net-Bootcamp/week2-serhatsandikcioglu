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
    [Route("api/v1/satellites")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {
        private readonly ISatelliteService _satelliteService;
        private readonly IPlanetService _planetService; 

        public SatelliteController(ISatelliteService satelliteService, IPlanetService planetService)
        {
            _satelliteService = satelliteService;
            _planetService = planetService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, int size = 10, decimal minTemprature = 0, string? sort = "", string? sortType = "")
        {
            List<SatelliteDTO> satelliteDTOs = _satelliteService.GetAll(page, size, minTemprature, sort, sortType);
            return Ok(satelliteDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            bool satelliteExist = _satelliteService.IsExist(id);
            if (satelliteExist)
            {
                SatelliteDTO satelliteDTO = _satelliteService.GetById(id);
                return Ok(satelliteDTO);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(SatelliteCreateDTO satelliteCreateDTO)
        {
            SatelliteDTO satalliteDTO = _satelliteService.Add(satelliteCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = satalliteDTO.Id }, satalliteDTO);
        }
        [HttpPut("{id}/planet/{planetId}")]
        public IActionResult Update(int id,int planetId,SatelliteUpdateDTO satelliteUpdateDTO)
        {
            bool satelliteExist = _satelliteService.IsExist(id);
            bool planetExist = _planetService.IsExist(id);
            if (satelliteExist && planetExist)
            {
                satelliteUpdateDTO.Id = id;
                satelliteUpdateDTO.PlanetId = planetId;
                _satelliteService.Update(satelliteUpdateDTO);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool satelliteExist = _satelliteService.IsExist(id);
            if (satelliteExist)
            {
                _satelliteService.Delete(id);
                return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Satellite> patchDoc)
        {
            bool satelliteExist = _satelliteService.IsExist(id);
            if (satelliteExist)
            {
                _satelliteService.Patch(id, patchDoc);
                return Ok();
            }
            return NotFound();
        }
    }
}
