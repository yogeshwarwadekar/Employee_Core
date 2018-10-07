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
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository DepartmentRepository;
        public DepartmentController(IDepartmentRepository _DepartmentRepository)
        {
            DepartmentRepository = _DepartmentRepository;
        }

        [HttpGet, Route("showDepartment")]
        public IEnumerable<Department> showDepartment()
        {
            var Department = DepartmentRepository.showDepartment();
            if (Department == null)
            {
                return null;
            }
            return Department.ToList();
        }
    }
}