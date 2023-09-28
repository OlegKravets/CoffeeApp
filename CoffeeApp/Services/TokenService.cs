using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoffeeApp.Services
{
    public class TokenService
    {
        private const string TokenKey = "CoffeeAppSecurityTokenKey09222023LearningMAUI";
        private readonly SymmetricSecurityKey _key;

        public TokenService()
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
        }

        public string CreateToken(string userName)
        {
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, userName)
            };

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescription));
        }
    }
}
