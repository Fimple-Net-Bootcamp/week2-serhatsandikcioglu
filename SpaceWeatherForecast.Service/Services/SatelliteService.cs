﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpaceWeatherForecast.Data.DTO_s.Satellite;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using SpaceWeatherForecast.Data.Repositories;
using SpaceWeatherForecast.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public SatelliteDTO Add(SatelliteCreateDTO satelliteCreateDTO)
        {
            Satellite satallite = _mapper.Map<Satellite>(satelliteCreateDTO);
            _satelliteRepository.Add(satallite);
            _unitOfWork.SaveChanges();
            SatelliteDTO satelliteDTO = _mapper.Map<SatelliteDTO>(satallite);
            return satelliteDTO;
        }

        public void Delete(int id)
        {
            _satelliteRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public List<SatelliteDTO> GetAll(int page, int size, decimal minTemprature, string? sort)
        {
            List<Satellite> satellites =  _satelliteRepository.GetAll(page, size, minTemprature, sort);
            List<SatelliteDTO> satelliteDTOs = _mapper.Map<List<SatelliteDTO>>(satellites);
            return satelliteDTOs;
        }

        public SatelliteDTO GetById(int id)
        {
            Satellite satellite =  _satelliteRepository.GetById(id);
            SatelliteDTO satelliteDTO = _mapper.Map<SatelliteDTO>(satellite);
            return satelliteDTO;
        }

        public bool IsExist(int id)
        {
            bool satelliteExist = _satelliteRepository.IsExist(id);
            return satelliteExist;
        }

        public void Patch(int id, JsonPatchDocument<Satellite> patchDoc)
        {
            Satellite satellite = _satelliteRepository.GetById(id);
            patchDoc.ApplyTo(satellite);
            _unitOfWork.SaveChanges();
        }

        public void Update(SatelliteUpdateDTO satelliteUpdateDTO)
        {
            Satellite satellite = _mapper.Map<Satellite>(satelliteUpdateDTO);
            _satelliteRepository.Update(satellite);
            _unitOfWork.SaveChanges();
        }
    }
}
