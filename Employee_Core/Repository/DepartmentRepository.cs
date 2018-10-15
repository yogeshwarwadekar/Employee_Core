using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        Employee_DatabaseContext db;
        public DepartmentRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public List<Department> showDepartment()
        { 
            if(db != null)
            {
                return db.Department.ToList();
            }
            return null;
        }
    }
}
