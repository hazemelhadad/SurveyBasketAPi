using SurveyBackets.BLL.Services.Interfaces;

namespace SurveyBackets.BLL.Services
{
    public class PollServices : IPollServices
    {
        readonly static public List<Poll> polls = [
        new Poll
        {
            ID = 1,
            Description = "ay kalam",
            Name = "hazem"
        }];

        public IEnumerable<Poll> GetAll()=> polls;

        public Poll? getById(int id)=>polls.SingleOrDefault(x => x.ID == id);

        public Poll? AddNew(Poll pool)
        {
            polls.Add(pool);
            return (pool);
        }

        
    }
}
