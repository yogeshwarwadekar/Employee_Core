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

        [Fact]
        public void showEmployee_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.showEmployee().ToArray();

            // Assert
            var items = Assert.IsType<List<EmployeeDetail>>(okResult.Length);
            Assert.Equal(1, items.Count);
        }
    }
}
