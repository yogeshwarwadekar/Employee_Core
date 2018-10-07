using Employee_Core.Models;
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

        public IEnumerable<Rating> showRating()
        {
            if(db!=null)
            {
                return db.Rating.ToList();
            }
            return null;
        }
    }
}
