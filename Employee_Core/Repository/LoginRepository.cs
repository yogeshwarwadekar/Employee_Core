using Employee_Core.Models;
using Employee_Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class LoginRepository : ILoginRepository
    {
        Employee_DatabaseContext db;
        public LoginRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }


        public Login getLogin(Login login)
        {
            try
            {
                if (db != null)
                {
                    return db.Login.FirstOrDefault(e => (e.UserName == login.UserName) && (e.Password == login.Password));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Login> showLogin()
        {
            try
            {
                return db.Login.ToList();
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
