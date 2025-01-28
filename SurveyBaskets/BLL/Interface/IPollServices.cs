namespace SurveyBackets.BLL.Services.Interfaces
{
    public interface IPollServices
    {
        Task <IEnumerable<Poll>> GetAllAsync();
        Task <Poll?> getByIdAsync(int id, CancellationToken cancellationToken = default);
        Task <Poll?> AddNewAsync(Poll pool,CancellationToken cancellationToken=default);
        Task <bool> UpdateAsync(int id, Poll poll,CancellationToken cancellationToken=default);
        Task <bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
 