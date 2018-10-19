using Employee_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Core.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDetail> showEmployee();
        Employee employeeDetail(int id);
        int addEmployee(Employee employee);
        int deleteEmployee(string employeeIds);
        int updateEmployee(int empID, Employee employee);
    }
}
