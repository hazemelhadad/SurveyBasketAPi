namespace SurveyBaskets.BLL.Contracts.Requests
{
    public record PollRequest(
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAta);




}


