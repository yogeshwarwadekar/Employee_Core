using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Models
{
    public class EmployeeDetail
    {
        public int Emp_ID { get; set; }
        public string Emp_First_Name { get; set; }
        public string Emp_Last_Name { get; set; }
        public string Emp_Email_ID { get; set; }
        public string Emp_Mobile_Number { get; set; }
        public int? Emp_State_ID { get; set; }
        public int? Emp_City_ID { get; set; }
        public int? Emp_Skill_ID { get; set; }
        public DateTime? Emp_DOB { get; set; }
        public DateTime? Emp_DOJ { get; set; }
        public int? Emp_Dept_ID { get; set; }
        public string Emp_Rating { get; set; }
        public string Department_Name { get; set; }
        public int Department_ID { get; set; }
        public string City_Name { get; set; }
        public int City_ID { get; set; }
        public string Skill_Name { get; set; }
        public int Skill_ID { get; set; }
        public string State_Name { get; set; }
        public int State_ID { get; set; }
    }
}
