using SurveyBaskets.BLL.Contracts.Authentication;

namespace SurveyBaskets.BLL.Interface
{
    public interface IAuthServices
    {
        Task<AuthResponse?>GetTokenAsync(string email,string password,CancellationToken cancellationToken=default);
    }
}
