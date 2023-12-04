using AutoMapper;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Mapper
{
    public class MapperProfile :Profile
    {
        public MapperProfile() 
        {
            CreateMap<Planet, PlanetDTO>().ReverseMap();
            CreateMap<Planet, PlanetCreateDTO>().ReverseMap();
            CreateMap<Planet, PlanetUpdateDTO>().ReverseMap();

            CreateMap<Satellite, SatelliteDTO>().ReverseMap();
            CreateMap<Satellite, SatelliteCreateDTO>().ReverseMap();
            CreateMap<Satellite, SatelliteUpdateDTO>().ReverseMap();
        }
        
    }
}
