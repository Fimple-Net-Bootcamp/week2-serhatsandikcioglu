using AutoMapper;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using SpaceWeatherForecast.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Service.Services
{
    public class SatelliteService : ISatelliteService
    {
        private readonly ISatelliteRepository _satelliteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SatelliteService(ISatelliteRepository satelliteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _satelliteRepository = satelliteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(SatelliteCreateDTO satellite)
        {
            Satellite mappedSatallite = _mapper.Map<Satellite>(satellite);
            _satelliteRepository.Add(mappedSatallite);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _satelliteRepository.Delete(id);
        }

        public List<Satellite> GetAll()
        {
            return _satelliteRepository.GetAll();
        }

        public Satellite GetById(int id)
        {
            return _satelliteRepository.GetById(id);
        }

        public void Update(SatelliteUpdateDTO satellite)
        {
            Satellite mappedSatellite = _mapper.Map<Satellite>(satellite);
            _satelliteRepository.Update(mappedSatellite);
            _unitOfWork.SaveChanges();
        }
    }
}
