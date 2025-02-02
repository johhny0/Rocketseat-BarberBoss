using Domain;
using Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Security
{
    public class JwtTokenGenerator(uint expirationTimeInMinutes, string signInKey) : IAccessTokenGenerator
    {
        private readonly uint _expirationTimeInMinutes = expirationTimeInMinutes;
        private readonly string _signInKey = signInKey;

        public string Generate(User user)
        {
            var claims = new List<Claim>()
            {
                new("Name", user.Name),
                new("Id", user.Id.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var secutiryToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(secutiryToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signInKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
