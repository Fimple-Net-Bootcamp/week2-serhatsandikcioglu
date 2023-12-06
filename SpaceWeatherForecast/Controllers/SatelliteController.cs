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
        public IActionResult GetAll([FromQuery]  decimal minTemprature, string? sort, int page = 1, int size = 10)
        {
            List<SatelliteDTO> satelliteDTOs = _satelliteService.GetAll(page, size, minTemprature, sort);
            return Ok(satelliteDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById( int id)
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
        public IActionResult Create([FromBody] SatelliteCreateDTO satelliteCreateDTO)
        {
            SatelliteDTO satalliteDTO = _satelliteService.Add(satelliteCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = satalliteDTO.Id }, satalliteDTO);

        }
        [HttpPut("{id}/planet/{planetId}")]
        public IActionResult UpdatePlanet( int id, int planetId, [FromBody] SatelliteUpdateDTO satelliteUpdateDTO)
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
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SatelliteUpdateDTO satelliteUpdateDTO)
        {
            bool satelliteExist = _satelliteService.IsExist(id);
            if (satelliteExist)
            {
                satelliteUpdateDTO.Id = id;
                _satelliteService.Update(satelliteUpdateDTO);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete( int id)
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
        public IActionResult Patch( int id, [FromBody] JsonPatchDocument<Satellite> patchDoc)
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
