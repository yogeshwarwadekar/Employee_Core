using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Core.Models;

namespace Employee_Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Employee_DatabaseContext db;
        public EmployeeRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public void addEmployee(Employee employee)
        {
            if (db != null)
            {
                try
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("add employee" + ex);
                }
            }
        }

        public void deleteEmployee(string employeeIds)
        {
            if (db != null)
            {
                try
                {
                    employeeIds = employeeIds.Substring(0, employeeIds.Length - 1);
                    int[] IDs = Array.ConvertAll(employeeIds.Split(','), int.Parse);
                    foreach (int i in IDs)
                    {
                        db.Employee.Remove(db.Employee.FirstOrDefault(e => e.EmpId == i));
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("delete employee : " + ex);
                }
            }
        }

        public Employee employeeDetail(int id)
        {
            if (db != null)
            {
                return db.Employee.FirstOrDefault(e => e.EmpId == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Employee> showEmployee()
        {
            if (db != null)
            {
                return db.Employee.ToList();
            }
            else
            {
                return null;
            }
        }

        public void updateEmployee(int empID, Employee employee)
        {
            if (db != null)
            {
                var entity = db.Employee.FirstOrDefault(e => e.EmpId == empID);

                entity.EmpFirstName = employee.EmpFirstName;
                entity.EmpLastName = employee.EmpLastName;
                entity.EmpEmailId = employee.EmpEmailId;
                entity.EmpMobileNumber = employee.EmpMobileNumber;
                entity.EmpStateId = Convert.ToInt32(employee.EmpStateId);
                entity.EmpCityId = Convert.ToInt32(employee.EmpCityId);
                entity.EmpSkillId = Convert.ToInt32(employee.EmpSkillId);
                entity.EmpDob = employee.EmpDob;
                entity.EmpDoj = employee.EmpDoj;
                entity.EmpDeptId = Convert.ToInt32(employee.EmpDeptId);
                entity.EmpRating = employee.EmpRating;

                db.SaveChanges();
            }
        }
    }
}
