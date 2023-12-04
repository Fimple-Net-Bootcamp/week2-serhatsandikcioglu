using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Service.Interfaces;

namespace SpaceWeatherForecast.Controllers
{
    [Route("api/v1/Planets/[action]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _planetService.GetAll(true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
            var result = _planetService.GetById(id);
            return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(PlanetCreateDTO planet)
        {
            var createdPlanet = _planetService.Add(planet);
            return CreatedAtAction(nameof(GetById),new {id = createdPlanet.Id},createdPlanet);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,PlanetUpdateDTO planet)
        {
            var planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
                planet.Id = id;
                _planetService.Update(planet);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var planetIsExist = _planetService.IsExist(id);
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
            var planetIsExist = _planetService.IsExist(id);
            if (planetIsExist)
            {
            _planetService.Patch(id,patchDoc);
            return Ok();
            }
            return NotFound();
        }
    }
}
