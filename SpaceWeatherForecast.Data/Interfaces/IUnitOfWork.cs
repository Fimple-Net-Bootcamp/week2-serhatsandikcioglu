﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWeatherForecast.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
