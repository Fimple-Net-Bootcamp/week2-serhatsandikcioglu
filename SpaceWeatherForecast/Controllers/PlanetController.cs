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
            List<PlanetDTO> planetDTOs = _planetService.GetAll(page , size,minTemprature,sort,sortType);
            return Ok(planetDTOs);
        }
        [HttpGet("{id}/satellites")]
        public IActionResult GetById(int id)
        {
            bool planetExist = _planetService.IsExist(id);
            if (planetExist)
            {
            PlanetDTO planetDTO = _planetService.GetById(id);
            return Ok(planetDTO);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(PlanetCreateDTO planetCreateDTO)
        {
            PlanetDTO planetDTO = _planetService.Add(planetCreateDTO);
            return CreatedAtAction(nameof(GetById),new {id = planetDTO.Id}, planetDTO);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,PlanetUpdateDTO planetUpdateDTO)
        {
            bool planetExist = _planetService.IsExist(id);
            if (planetExist)
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
            bool planetExist = _planetService.IsExist(id);
            if (planetExist)
            {
            _planetService.Delete(id);
            return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Planet> patchDoc)
        {
            bool planetExist = _planetService.IsExist(id);
            if (planetExist)
            {
            _planetService.Patch(id,patchDoc);
            return Ok();
            }
            return NotFound();
        }
    }
}
