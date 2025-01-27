namespace SurveyBackets.BLL.Services.Interfaces
{
    public interface IPollServices
    {
        Task <IEnumerable<Poll>> GetAllAsync();
        Task <Poll?> getByIdAsync(int id);
        Task <Poll?> AddNewAsync(Poll pool);
        Task <bool> UpdateAsync(int id, Poll poll);
        //public bool Delete(int id);
    }
}
 