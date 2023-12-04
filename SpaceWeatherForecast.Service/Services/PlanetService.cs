using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SpaceWeatherForecast.Data.DTO_s.Planet;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using SpaceWeatherForecast.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanetService(IPlanetRepository planetRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _planetRepository = planetRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Planet Add(PlanetCreateDTO planet)
        {
            Planet mappedPlanet = _mapper.Map<Planet>(planet);
            _planetRepository.Add(mappedPlanet);
            _unitOfWork.SaveChanges();
            return mappedPlanet;
        }

        public void Delete(int id)
        {
            _planetRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public List<Planet> GetAll(bool relational)
        {
           return _planetRepository.GetAll(relational);
        }

        public Planet GetById(int id)
        {
            return _planetRepository.GetById(id);
        }

        public bool IsExist(int id)
        {
           var result = _planetRepository.IsExist(id);
            return result;
        }

        public void Update(PlanetUpdateDTO planet)
        {
            var mappedPlanet = _mapper.Map<Planet>(planet);
            _planetRepository.Update(mappedPlanet);
            _unitOfWork.SaveChanges();
        }
        public void Patch(int id, JsonPatchDocument<Planet> patchDoc)
        {
            //JsonPatchDocument<Planet> document = JsonConvert.DeserializeObject<JsonPatchDocument<Planet>>(patchDoc);
            var planet = _planetRepository.GetById(id);
            patchDoc.ApplyTo(planet);
            _unitOfWork.SaveChanges();
        }
    }
}
