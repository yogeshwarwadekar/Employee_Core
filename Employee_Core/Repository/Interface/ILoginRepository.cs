using Employee_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository.Interface
{
    public interface ILoginRepository
    {
        Login getLogin(Login login);

        List<Login> showLogin();
    }
}
