using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.DTO_s;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly DbSet<Planet> _dbSet;
        public PlanetRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Planet>();
        }
        public void Add(Planet planet)
        {
            _dbSet.Add(planet);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        public List<Planet> GetAll(int page , int size, decimal minTemprature, string? sort, string? sortType)
        {
            IQueryable<Planet> query = _dbSet.AsQueryable();
            if (minTemprature != null)
            {
                query = query.Where(t => t.Temprature >= minTemprature);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort.ToLower())
                {
                    case "name":
                        query = sortType == "desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                        break;

                    case "temprature":
                        query = sortType == "desc" ? query.OrderByDescending(p => p.Temprature) : query.OrderBy(p => p.Temprature);
                        break;

                    default:
                        query = query.OrderBy(p => p.Id);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(p => p.Id);
            }
            int skipCount = (page - 1) * size;
            query = query.Skip(skipCount).Take(size);
            return query.ToList();
        }

        public Planet GetById(int id)
        {
            var planet = _dbSet.Find(id);
            if (planet != null)
            {
                _dbSet.Entry(planet).Collection(p => p.Satellites).Load();
            }
            return planet;
        }   

        public void Update(Planet planet)
        {
            _dbSet.Update(planet);
        }
        public bool IsExist(int id)
        {
            bool result = _dbSet.Any(x => x.Id == id);
            return result;
        }
    }
}
