using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class CityRepository:ICityRepository
    {
        Employee_DatabaseContext db;
        public CityRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public List<City> showCity(int statevalue)
        {
            try
            {
                var cities = from city_List in db.City
                             where city_List.State_ID == statevalue
                             select city_List;

                return  cities.ToList();
            }
            catch (Exception ex)
            {                
                Console.WriteLine("show city" + ex);
                return null;
            }
        }
    }
}
