using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Core.Models;
using Employee_Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityRepository CityRepository;
        public CityController(ICityRepository _CityRepository)
        {
            CityRepository = _CityRepository;
        }

        [HttpGet, Route("showCity")]
        public IEnumerable<City> showCity(int stateValue)
        {
            var city = CityRepository.showCity(stateValue);
            if (city == null)
            {
                return null;
            }
            return city.ToList();
        }
    }
}