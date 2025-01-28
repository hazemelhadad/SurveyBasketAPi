﻿namespace SurveyBaskets.BLL.Contracts.Polls
{
    public record PollResponse
        (
        int Id,
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAta
        );

}
