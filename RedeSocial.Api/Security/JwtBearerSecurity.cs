using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedeSocial.Api.Security
{
    public class JwtBearerSecurity
    {
        private readonly string? _securityKey;
        private readonly string? _expirationInHours;

        public JwtBearerSecurity(string? securityKey, string? expirationInHours)
        {
            _securityKey = securityKey;
            _expirationInHours = expirationInHours;
        }

        public string GenerateToken(Guid id)
        {
            #region Gerar o token JWT

            var jwtSecurityToken = new JwtSecurityToken(
                claims: CreateClaims(id.ToString()),
                signingCredentials: CreateCredentials(),
                expires: GetExpiration()
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);

            #endregion
        }

        public DateTime GetExpiration()
        {
            return DateTime.Now.AddHours(Convert.ToDouble(_expirationInHours));
        }

        private SigningCredentials CreateCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return credentials;
        }

        private Claim[] CreateClaims(string id)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, id)
            };

            return claims;
        }
    }
}