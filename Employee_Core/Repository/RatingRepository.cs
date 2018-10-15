using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class RatingRepository:IRatingRepository
    {
        Employee_DatabaseContext db;
        public RatingRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public List<Rating> showRating()
        {
            if(db!=null)
            {
                return db.Rating.ToList();
            }
            return null;
        }
    }
}
