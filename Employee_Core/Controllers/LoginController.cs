using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Employee_Core.JWT;
using Employee_Core.Models;
using Employee_Core.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepository loginRepository;
        public LoginController(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }


        [HttpPost, Route("getLogin")]
        public Login getLogin(Login login)
        {
            var loginUsed = loginRepository.getLogin(login);
            try
            {
                return loginUsed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("login detail = " + ex);
                return null;
            }
        }



        [HttpPost, Route("jwtLogin")]
        public string jwtLogin(Login login)
        {
            Login user = getLogin(login);
            if (user != null)
            {
                AuthenticationModule authentication = new AuthenticationModule();
                string token = authentication.GenerateTokenForUser(user.UserName, user.UserID);
                return token;
            }
            else
            {
                return null;
            }
        }


        [HttpGet, Route("showLogin")]
        public List<Login> showLogin()
        {
            try
            {
                var loginUsed = loginRepository.showLogin();
                return loginUsed;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}