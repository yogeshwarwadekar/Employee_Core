using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Core.JWT
{
    public class AuthenticationModule
    {
        private const string communicationKey = "GQDstc21ewfffffffffffFiwDffVvVBrk";
        SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));

        // The Method is used to generate token for user
        public string GenerateTokenForUser(string userName, int userId)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = "http://localhost:60173",
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddYears(1),
                Issuer = "http://localhost:60173",
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }


        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudiences = new string[] { "http://localhost:44360" },
                ValidIssuers = new string[] { "http://localhost:44360" },
                ValidateIssuer = true,
                IssuerSigningKey = signingKey,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;
            }
            return validatedToken as JwtSecurityToken;
        }


        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
            return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name };
        }
    }
}
