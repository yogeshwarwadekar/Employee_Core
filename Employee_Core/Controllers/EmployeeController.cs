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
        public int addEmployee(Employee employee)
        {
            int intReturn;
            try
            {
                intReturn  = EmployeeRepository.addEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);
                intReturn = 1;                
            }
            return intReturn;
        }
        

        [HttpDelete, Route("deleteEmployee")]
        public int deleteEmployee(string employeeIds)
        {
            int intReturn;
            try
            { 
                 intReturn = EmployeeRepository.deleteEmployee(employeeIds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);
                intReturn = 1;
            }
            return intReturn;
        }
        

        [HttpPut, Route("updateEmployee")]
        public int updateEmployee(int empID, Employee employee)
        {
            int intReturn;
            try
            { 
                 intReturn = EmployeeRepository.updateEmployee(empID, employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("add Employee = " + ex);
                intReturn = 1;
            }
            return intReturn;
        }
    }
}