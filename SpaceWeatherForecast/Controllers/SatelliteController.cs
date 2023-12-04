using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Service.Interfaces;
using SpaceWeatherForecast.Service.Services;

namespace SpaceWeatherForecast.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {
        private readonly ISatelliteService _satelliteService;

        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _satelliteService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _satelliteService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(SatelliteCreateDTO satellite)
        {
            _satelliteService.Add(satellite);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(SatelliteUpdateDTO satellite)
        {
            _satelliteService.Update(satellite);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _satelliteService.Delete(id);
            return Ok();
        }
    }
}
