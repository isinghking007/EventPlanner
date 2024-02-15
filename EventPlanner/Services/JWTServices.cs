using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EventPlanner.Services
{
    public class JWTServices
    {
        public string SecretKey { get; set; }
        public int TokenDuuration { get; set; }
        private readonly IConfiguration _config;
        public JWTServices(IConfiguration iconfig) 
        {
            _config = iconfig;
            this.SecretKey = _config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuuration = Int32.Parse(_config.GetSection("jwtConfig").GetSection("duration").Value);
        }

        public String GenerateToken(string userid,string firstName,string lastName,string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("userId",userid),
                new Claim("FirstName",firstName),
                new Claim("LastName",lastName),
                new Claim("email",email)
            };
            var jwtToken = new JwtSecurityToken(
              issuer: "localhost",
              audience: "localhost",
              claims: payload,
              expires: DateTime.Now.AddMinutes(TokenDuuration),
              signingCredentials: signature
              );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        public String GenerateLoginToken(string loginId, string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("LoginId",loginId),
                new Claim("email",email)
            };
            var jwtToken = new JwtSecurityToken(
              issuer: "localhost",
              audience: "localhost",
              claims: payload,
              expires: DateTime.Now.AddMinutes(TokenDuuration),
              signingCredentials: signature
              );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
