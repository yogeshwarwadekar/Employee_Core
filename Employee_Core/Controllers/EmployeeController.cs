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
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository EmployeeRepository;
        public EmployeeController(IEmployeeRepository _EmployeeRepository)
        {
            EmployeeRepository = _EmployeeRepository;
        }


        [HttpGet, Route("showEmployee")]
        public IEnumerable<Employee> showEmployee()
        {
            var employees = EmployeeRepository.showEmployee();
            if (employees == null)
            {
                return null;
            }
            return employees.ToList();
        }


        [HttpGet, Route("employeeDetail")]
        public Employee employeeDetail(int id)
        {
            var employees = EmployeeRepository.employeeDetail(id);
            if (employees == null)
            {
                return null;
            }
            return employees;
        }
        

        [HttpPost, Route("addEmployee")]
        public void addEmployee(Employee employee)
        {
            EmployeeRepository.addEmployee(employee);
        }
        

        [HttpDelete, Route("deleteEmployee")]
        public void deleteEmployee(string employeeIds)
        {
            EmployeeRepository.deleteEmployee(employeeIds);
        }
        

        [HttpPut, Route("updateEmployee")]
        public void updateEmployee(int empID, Employee employee)
        {
            EmployeeRepository.updateEmployee(empID, employee);
        }
    }
}