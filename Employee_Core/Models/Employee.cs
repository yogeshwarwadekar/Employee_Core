using System;
using System.Collections.Generic;

namespace Employee_Core.Models
{
    public partial class Employee
    {
        public int Emp_ID { get; set; }
        public string Emp_First_Name { get; set; }
        public string Emp_Last_Name { get; set; }
        public string Emp_Email_ID { get; set; }
        public string Emp_Mobile_Number { get; set; }
        public int? Emp_State_ID { get; set; }
        public int? Emp_City_ID { get; set; }
        public int? Emp_Skill_ID { get; set; }
        public DateTime? Emp_Dob { get; set; }
        public DateTime? Emp_Doj { get; set; }
        public int? Emp_Dept_ID { get; set; }
        public string Emp_Rating { get; set; }
    }
}
