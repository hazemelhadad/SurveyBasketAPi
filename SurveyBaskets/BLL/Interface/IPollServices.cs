namespace SurveyBackets.BLL.Services.Interfaces
{
    public interface IPollServices
    {
        public IEnumerable<Poll> GetAll();
        public Poll? getById(int id);
        public Poll? AddNew(Poll pool);
    }
}
