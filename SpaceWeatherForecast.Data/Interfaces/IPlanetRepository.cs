﻿using SpaceWeatherForecast.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Interfaces
{
    public interface IPlanetRepository
    {
        public List<Planet> GetAll(int page, int size, decimal minTemprature, string? sort);
        Planet GetById(int id);
        void Add(Planet planet);
        void Delete(int id);
        void Update(Planet planet);
        bool IsExist(int id);
    }
}
