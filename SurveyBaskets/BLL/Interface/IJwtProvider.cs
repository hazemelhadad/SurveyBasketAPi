using SurveyBaskets.DAL.Entities;

namespace SurveyBaskets.BLL.Interface
{
    public interface IJwtProvider
    {
        (string token, int expiresIn)GenerateToken(ApplicationUser user);

    }
}
