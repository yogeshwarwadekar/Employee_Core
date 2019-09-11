using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Models
{
    public partial class Login
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
