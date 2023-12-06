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


        public PlanetDTO Add(PlanetCreateDTO planetCreateDTO)
        {
            Planet planet = _mapper.Map<Planet>(planetCreateDTO);
            _planetRepository.Add(planet);
            _unitOfWork.SaveChanges();
            PlanetDTO planetDTO = _mapper.Map<PlanetDTO>(planet);
            return planetDTO;
        }

        public void Delete(int id)
        {
            _planetRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public List<PlanetDTO> GetAll(int page, int size, decimal minTemprature, string? sort, string? sortType)
        {
           List<Planet> planets =  _planetRepository.GetAll(page,size,minTemprature,sort,sortType);
            List<PlanetDTO> planetDTOs = _mapper.Map<List<PlanetDTO>>(planets);
            return planetDTOs;
        }

        public PlanetDTO GetById(int id)
        {
            Planet planet =  _planetRepository.GetById(id);
            PlanetDTO planetDTO = _mapper.Map<PlanetDTO>(planet);
            return planetDTO;
        }

        public bool IsExist(int id)
        {
           bool result = _planetRepository.IsExist(id);
            return result;
        }

        public void Update(PlanetUpdateDTO planetUpdateDTO)
        {
            Planet planet = _mapper.Map<Planet>(planetUpdateDTO);
            _planetRepository.Update(planet);
            _unitOfWork.SaveChanges();
        }
        public void Patch(int id, JsonPatchDocument<Planet> patchDoc)
        {
            //JsonPatchDocument<Planet> document = JsonConvert.DeserializeObject<JsonPatchDocument<Planet>>(patchDoc);
            Planet planet = _planetRepository.GetById(id);
            patchDoc.ApplyTo(planet);
            _unitOfWork.SaveChanges();
        }
    }
}
