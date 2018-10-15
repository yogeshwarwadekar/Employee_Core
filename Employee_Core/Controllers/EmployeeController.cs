using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<EmployeeDetail> showEmployee()
        {
            var employees =  EmployeeRepository.showEmployee();
            try
            {
                if (employees != null)
                {
                    return employees.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("show employee = " + ex);
                return null;
            }
        }


        [HttpGet, Route("employeeDetail")]
        public Employee employeeDetail(int id)
        {
            var employees =  EmployeeRepository.employeeDetail(id);
            try
            {
                if (employees == null)
                {
                    return null;
                }
                else
                {
                    return employees;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("employee detail = " + ex);
                return null;
            }
        }
        

        [HttpPost, Route("addEmployee")]
        public void addEmployee(Employee employee)
        {
            try
            {
                 EmployeeRepository.addEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);                
            }
        }
        

        [HttpDelete, Route("deleteEmployee")]
        public void deleteEmployee(string employeeIds)
        {
            try
            { 
                 EmployeeRepository.deleteEmployee(employeeIds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);                
            }
        }
        

        [HttpPut, Route("updateEmployee")]
        public void updateEmployee(int empID, Employee employee)
        {
            try
            { 
                 EmployeeRepository.updateEmployee(empID, employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);
            }
        }
    }
}