using Microsoft.AspNetCore.Identity;
using SurveyBaskets.BLL.Contracts.Authentication;
using SurveyBaskets.BLL.Interface;
using SurveyBaskets.DAL.Entities;

namespace SurveyBaskets.BLL.Services
{
    public class AuthServices(UserManager<ApplicationUser> _userManager,IJwtProvider jwtProvider) : IAuthServices
    {
        private readonly UserManager<ApplicationUser> userManager = _userManager;
        private readonly IJwtProvider jwtProvider = jwtProvider;

        public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            // check user 
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return null;

            // check pass
            var pass= userManager.CheckPasswordAsync(user, password);
            if(pass is null)
                return null;

            //generate JWT Token

            var (token, expiresIn) = jwtProvider.GenerateToken(user);

            //Return New Auth Response()
            return new AuthResponse(user.Id,user.Email,user.FirstName,user.LastName,token,expiresIn);

        }
    }
}
