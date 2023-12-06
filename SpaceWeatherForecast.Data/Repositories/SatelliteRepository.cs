using Microsoft.EntityFrameworkCore;
using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.Entities;
using SpaceWeatherForecast.Data.Interfaces;
using System.Linq.Dynamic.Core;
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

        public List<Satellite> GetAll(int page, int size, decimal minTemprature, string? sort)
        {
            IQueryable<Satellite> query = _dbSet.AsQueryable();
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
