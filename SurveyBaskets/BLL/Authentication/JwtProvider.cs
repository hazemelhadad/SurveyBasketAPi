using Microsoft.IdentityModel.Tokens;
using SurveyBaskets.BLL.Interface;
using SurveyBaskets.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBaskets.BLL.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        // tuble return diferrence things 
        (string token, int expiresIn) IJwtProvider.GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tyffdKAInPGk2EgXx6G6l26BL7gdj1wO"));
            var Credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                    issuer: "SurveyBasket",
                    audience: "Hazem",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: Credentials
                );
            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: 30);
        }
    }
}
