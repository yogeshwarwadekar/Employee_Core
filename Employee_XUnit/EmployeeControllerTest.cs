using System;
using Xunit;
using Employee_Core.Controllers;
using Employee_Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Employee_Core.Models;
using System.Collections.Generic;

namespace Employee_XUnit
{
    public class EmployeeControllerTest
    {
        EmployeeController _controller;
        IEmployeeRepository _service;

        public EmployeeControllerTest()
        {
            _service = new EmployeeRepositoryFake();
            _controller = new EmployeeController(_service);
        }

        [Fact]
        public void showEmployee_WhenCalled_ReturnsOkResult()
        {            
            var okResult = _controller.showEmployee(); // Act
                        
            var items = Assert.IsType<List<EmployeeDetail>>(okResult.Count); // Assert
            Assert.Equal(1, Convert.ToInt32(items));
        }


        [Fact]
        public void addEmployee_WhenCalled_ReturnsOkResult()
        {            
            var employeeItem = new Employee()
            {
                Emp_ID = 3,
                Emp_First_Name = "Purvi",
                Emp_Last_Name = "Wadekar",
                Emp_Email_ID = "purvi.wadekar@gmail.com",
                Emp_Mobile_Number = "9685748596",
                Emp_State_ID = 1,
                Emp_City_ID = 1,
                Emp_Skill_ID = 1,
                Emp_Dob = DateTime.Parse("1988-01-17"),
                Emp_Doj = DateTime.Parse("2012-01-16"),
                Emp_Dept_ID = 1,
                Emp_Rating = "Exceed Far"
            }; // Arrange

            var okResult = _controller.addEmployee(employeeItem); // Act                
                
            var items = Assert.IsType<List<Employee>>(okResult.ToString()); // Assert
            Assert.Equal("0",items.ToString());
        }


        [Fact]
        public void updateEmployee_WhenCalled_ReturnsOkResult()
        {
            var employeeItem = new Employee()
            {
                Emp_ID = 3,
                Emp_First_Name = "Purvi",
                Emp_Last_Name = "Wadekar",
                Emp_Email_ID = "purvi.wadekar@gmail.com",
                Emp_Mobile_Number = "9685748596",
                Emp_State_ID = 1,
                Emp_City_ID = 1,
                Emp_Skill_ID = 1,
                Emp_Dob = DateTime.Parse("2014-08-28"),
                Emp_Doj = DateTime.Parse("2012-01-16"),
                Emp_Dept_ID = 1,
                Emp_Rating = "Exceed Far"
            }; // Arrange

            var okResult = _controller.updateEmployee(3,employeeItem); // Act                

            var items = Assert.IsType<List<Employee>>(okResult.ToString()); // Assert
            Assert.Equal("0", items.ToString());
        }

        [Fact]
        public void deleteEmployee_WhenCalled_ReturnsOkResult()
        {
            string employeeIds = "3";
            var okResult = _controller.deleteEmployee(employeeIds); // Act                

            var items = Assert.IsType<List<Employee>>(okResult.ToString()); // Assert
            Assert.Equal("0", items.ToString());
        }
    }
}
