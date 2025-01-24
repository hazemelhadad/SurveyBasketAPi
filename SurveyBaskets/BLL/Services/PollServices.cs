using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBackets.BLL.Services.Interfaces;

namespace SurveyBackets.BLL.Services
{
    public class PollServices : IPollServices
    {
        static int id = 0;
        readonly static public List<Poll> polls = [
        new Poll
        {
            ID =id,
            Description = "ay kalam",
            Name = "hazem"
        }];

        public IEnumerable<Poll> GetAll()=> polls;

        public Poll? getById(int id)=>polls.SingleOrDefault(x => x.ID == id);

        public Poll? AddNew(Poll pool)
        {
            pool.ID = id;
            polls.Add(pool);
            id++;
            return (pool);
        }

        public bool Update(int id, Poll poll)
        {
            var po=getById(id);
            if(po is null)
                return false;
            else {
                po.Description = poll.Description;
                po.Name = poll.Name;
                return true;
                
            }
        }

        public bool Delete(int id)
        {
            
            var result=getById(id);
            if (result is null)
                return false;
            else
            {
                polls.Remove(result);
                return true;
            }
        }
    }
}
