using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Service.Interfaces;

namespace SpaceWeatherForecast.Controllers
{
    [Route("api/v1/planets")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, int size = 10, decimal minTemprature = 0, string? sort = "", string? sortType = "")
        {
            List<Planet> planets = _planetService.GetAll(page , size,minTemprature,sort,sortType);
            return Ok(planets);
        }
        [HttpGet("{id}/satellites")]
        public IActionResult GetById(int id)
        {
            bool planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
            Planet planet = _planetService.GetById(id);
            return Ok(planet);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(PlanetCreateDTO planetCreateDTO)
        {
            PlanetDTO createdPlanet = _planetService.Add(planetCreateDTO);
            return CreatedAtAction(nameof(GetById),new {id = createdPlanet.Id},createdPlanet);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,PlanetUpdateDTO planetUpdateDTO)
        {
            bool planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
                planetUpdateDTO.Id = id;
                _planetService.Update(planetUpdateDTO);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
            _planetService.Delete(id);
            return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Planet> patchDoc)
        {
            bool planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
            _planetService.Patch(id,patchDoc);
            return Ok();
            }
            return NotFound();
        }
    }
}
