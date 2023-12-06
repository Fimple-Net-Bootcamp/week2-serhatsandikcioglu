using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.DTO_s;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using System.Linq.Dynamic.Core;
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

        public List<Planet> GetAll(int page , int size, decimal minTemprature, string? sort)
        {
            IQueryable<Planet> query = _dbSet.AsQueryable();
            if (minTemprature != null)
            {
                query = query.Where(t => t.Temprature >= minTemprature);
                
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var sortParts = sort.Split(' ');

                if (sortParts.Length == 2 && (sortParts[1].ToLower() == "asc" || sortParts[1].ToLower() == "desc"))
                {
                    string propertyName = sortParts[0].ToLower();

                    var validProperties = typeof(Planet).GetProperties().Select(p => p.Name.ToLower());

                    if (validProperties.Contains(propertyName))
                    {
                        query = query.AsQueryable().OrderBy(sort);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Id);
                    }
                }
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
