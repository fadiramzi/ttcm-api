using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class JwtService
    {
        private readonly IConfiguration Configuration;

        public JwtService(IConfiguration conf)
        {
            Configuration = conf;
        }
        public string GenerateJWT(User user, string Role)
        {
            var jwtSettings = Configuration.GetSection("Jwt");

            var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim("role", Role),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        };
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var signInCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireInMinutes"])),
                signingCredentials: signInCred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
