namespace SurveyBaskets.BLL.Contracts.Requests
{
    public record CreatePollRequest(
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAta);




}


