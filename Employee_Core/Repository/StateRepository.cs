using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class StateRepository:IStateRepository
    {
        Employee_DatabaseContext db;
        public StateRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public List<State> showState()
        {
            if(db != null)
            {
                return db.State.ToList();
            }
            return null;
        }
    }
}
