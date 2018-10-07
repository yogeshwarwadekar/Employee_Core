using Employee_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public interface IEmployeeRepository
    {        
        IEnumerable<Employee> showEmployee();
        Employee employeeDetail(int id);
        void addEmployee(Employee employee);
        void deleteEmployee(string employeeIds);
        void updateEmployee(int empID, Employee employee);
    }
}
