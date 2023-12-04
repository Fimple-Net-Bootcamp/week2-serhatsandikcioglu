using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
