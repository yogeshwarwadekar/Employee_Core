﻿using Employee_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public interface ICityRepository
    {
        IEnumerable<City> showCity(int statevalue);
    }
}