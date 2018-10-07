using System;
using System.Collections.Generic;

namespace Employee_Core.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpMobileNumber { get; set; }
        public int? EmpStateId { get; set; }
        public int? EmpCityId { get; set; }
        public int? EmpSkillId { get; set; }
        public DateTime? EmpDob { get; set; }
        public DateTime? EmpDoj { get; set; }
        public int? EmpDeptId { get; set; }
        public string EmpRating { get; set; }
    }
}
