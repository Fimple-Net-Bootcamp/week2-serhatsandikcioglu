using Microsoft.EntityFrameworkCore;
using SpaceWeatherForecast.Data.DataBase;
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

        public List<Planet> GetAll(bool relational = false)
        {
            if (relational == true)
            {
            return _dbSet.Include(x=>x.Satellites).ToList();
            }
            else
            {
                return _dbSet.ToList();
            }
        }

        public Planet GetById(int id)
        {
            return _dbSet.Find(id);
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
