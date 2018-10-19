using Employee_Core.Models;
using Employee_Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee_XUnit
{
    public class EmployeeRepositoryFake : IEmployeeRepository
    {
        private readonly List<Employee> _Employee;
        private readonly List<EmployeeDetail> _EmployeeDetail;

        public EmployeeRepositoryFake()
        {

            _Employee = new List<Employee>()
            {
                #region Dummy Record 1
                new Employee()
                {
                    Emp_ID = 1,
                    Emp_First_Name="Yogeshwar",
                    Emp_Last_Name="Wadekar",
                    Emp_Email_ID="yogeshwar.wadekar@gmail.com",
                    Emp_Mobile_Number="9685748596",
                    Emp_State_ID=1,
                    Emp_City_ID=1,
                    Emp_Skill_ID=1,
                    Emp_Dob=DateTime.Parse("1988-01-17"),
                    Emp_Doj=DateTime.Parse("2012-01-16"),
                    Emp_Dept_ID =1,
                    Emp_Rating="Exceed Far"
                },
                #endregion

                #region Dummy Record 2
                new Employee()
                {
                    Emp_ID = 2,
                    Emp_First_Name="Mohini",
                    Emp_Last_Name="Wadekar",
                    Emp_Email_ID="Mohini.wadekar@gmail.com",
                    Emp_Mobile_Number="9685748596",
                    Emp_State_ID=2,
                    Emp_City_ID=5,
                    Emp_Skill_ID=1,
                    Emp_Dob=DateTime.Parse("1989-02-18"),
                    Emp_Doj=DateTime.Parse("2013-02-17"),
                    Emp_Dept_ID =2,
                    Emp_Rating="Exceed Far"
                }
                #endregion
            };

            _EmployeeDetail = new List<EmployeeDetail>()
            {
                #region Dummy Record 1
                new EmployeeDetail(){
                    Emp_ID = 1,
                    Emp_First_Name = "Yogeshwar",
                    Emp_Last_Name = "Wadekar",
                    Emp_Email_ID = "yogeshwar.wadekar@gmail.com",
                    Emp_Mobile_Number = "9685747896",
                    Emp_State_ID = 1,
                    Emp_City_ID=1,
                    Emp_Skill_ID = 1,
                    Emp_DOB = DateTime.Parse("1988-01-17"),
                    Emp_DOJ = DateTime.Parse("1989-02-18"),
                    Emp_Dept_ID = 1,
                    Emp_Rating = "Exceed Many",
                    Department_Name = "Developement",
                    Department_ID = 1,
                    City_Name = "Dhule",
                    City_ID = 1,
                    Skill_Name = "Angular4",
                    Skill_ID = 1,
                    State_Name = "Maharashtra",
                    State_ID = 1
                }
                #endregion
            };
        }

        public int addEmployee(Employee employee)
        {
            try
            {
                _Employee.Add(employee);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("add employee = " + ex);
                return 1;
            }
        }

        public int deleteEmployee(string employeeIds)
        {
            try
            {
                employeeIds = employeeIds.Substring(0, employeeIds.Length - 1);
                int[] IDs = Array.ConvertAll(employeeIds.Split(','), int.Parse);
                foreach (int i in IDs)
                {
                    _Employee.Remove(_Employee.Find(a => a.Emp_ID == i));
                }
                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("delete employee = " + ex);
                return 1;
            }            
        }

        public Employee employeeDetail(int id)
        {
            return _Employee.Find(a => a.Emp_ID == id);
        }

        public List<EmployeeDetail> showEmployee()
        {
            return _EmployeeDetail;
        }

        public int updateEmployee(int empID, Employee employee)
        {
            try
            {
                var emp = _Employee.Find(a => a.Emp_ID == empID);
                _Employee[1].Emp_First_Name = employee.Emp_First_Name;
                _Employee[1].Emp_Last_Name = employee.Emp_Last_Name;
                _Employee[1].Emp_Email_ID = employee.Emp_Email_ID;
                _Employee[1].Emp_City_ID = employee.Emp_City_ID;
                _Employee[1].Emp_Dept_ID = employee.Emp_Dept_ID;
                _Employee[1].Emp_Dob = employee.Emp_Dob;
                _Employee[1].Emp_Doj = employee.Emp_Doj;
                _Employee[1].Emp_Mobile_Number = employee.Emp_Mobile_Number;
                _Employee[1].Emp_Rating = employee.Emp_Rating;
                _Employee[1].Emp_Skill_ID = employee.Emp_Skill_ID;
                _Employee[1].Emp_State_ID = employee.Emp_State_ID;
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("update employee = " + ex);
                return 1;
            }
        }

    }
}
