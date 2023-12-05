using Microsoft.EntityFrameworkCore;
using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<Satellite> GetAll(int page, int size, decimal minTemprature, string? sort, string? sortType)
        {
            IQueryable<Satellite> query = _dbSet.AsQueryable();
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

        public Satellite GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool IsExist(int id)
        {
            bool result = _dbSet.Any(x => x.Id == id);
            return result;
        }

        public void Update(Satellite satellite)
        {
            _dbSet.Update(satellite);
        }
    }
}
