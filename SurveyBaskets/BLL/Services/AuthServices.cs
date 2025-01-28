using Microsoft.AspNetCore.Identity;
using SurveyBaskets.BLL.Contracts.Authentication;
using SurveyBaskets.BLL.Interface;
using SurveyBaskets.DAL.Entities;

namespace SurveyBaskets.BLL.Services
{
    public class AuthServices(UserManager<ApplicationUser> _userManager) : IAuthServices
    {
        private readonly UserManager<ApplicationUser> userManager = _userManager;

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



            //Return New Auth Response()
            return new AuthResponse(user.Id,user.Email,user.FirstName,user.LastName, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",3600);

        }
    }
}
