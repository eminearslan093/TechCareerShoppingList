using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Tools.JwtTools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenReponse GenerateToken(UserDto dto)
        {
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenSettings.Expire);
            //var expireDate = DateTime.UtcNow.AddMinutes(1); //test ederken bunu açmaya unutma (1 dakikalık hatırlatma)


            var securitKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securitKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            claims.Add(new Claim(ClaimTypes.Name, dto.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenSettings.Issuer,
                audience: JwtTokenSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(JwtTokenSettings.Expire),
                signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new JwtTokenReponse(handler.WriteToken(token), expireDate);
        }
    }
}
