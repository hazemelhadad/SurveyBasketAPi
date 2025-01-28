namespace SurveyBaskets.BLL.Contracts.Authentication
{
    public record LoginRequest(
        string Email,
        string Password
        );
    
}
