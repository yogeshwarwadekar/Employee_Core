using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Employee_Core.Models;
using Employee_Core.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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


        [HttpPost, Route("jwtLogin")]
        public string jwtLogin(Login login)
        {
            Login user = getLogin(login);
            if (user == null)
            {
                return "Invalid client request";
            }

            if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            else
            {
                return "Unauthorized";
            }
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