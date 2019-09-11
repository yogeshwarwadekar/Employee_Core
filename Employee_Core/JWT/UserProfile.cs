using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.JWT
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
