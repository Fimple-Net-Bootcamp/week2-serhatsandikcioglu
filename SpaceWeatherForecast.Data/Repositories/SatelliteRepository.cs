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
    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly DbSet<Satellite> _dbSet;
        public SatelliteRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<Satellite>();
        }
        public void Add(Satellite satellite)
        {
            _dbSet.Add(satellite);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        public List<Satellite> GetAll()
        {
            return _dbSet.ToList();
        }

        public Satellite GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(Satellite satellite)
        {
            _dbSet.Update(satellite);
        }
    }
}
