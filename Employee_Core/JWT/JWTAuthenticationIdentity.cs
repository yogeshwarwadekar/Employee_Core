using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Employee_Core.JWT
{
    public class JWTAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }

        public JWTAuthenticationIdentity(string userName)
            : base(userName)
        {
            UserName = userName;
        }
    }
}
