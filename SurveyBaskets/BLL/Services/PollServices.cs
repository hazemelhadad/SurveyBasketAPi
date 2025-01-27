using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBackets.BLL.Services.Interfaces;
using SurveyBaskets.DAL.Persistence;

namespace SurveyBackets.BLL.Services
{
    public class PollServices(ApplicationDBContext _db) : IPollServices
    {
        private readonly ApplicationDBContext db = _db;

        // .......AsNoTracking()  tell him that i will not make any edit in the retrived data  and make entity frame work not tracking the changes happened to this model
        public async Task<IEnumerable<Poll>> GetAllAsync() =>
            await db.polls.AsNoTracking().ToListAsync();

        public async Task<Poll?> getByIdAsync(int id) =>
            await db.polls.FindAsync(id);
            

        public async Task<Poll?> AddNewAsync(Poll pool)
        {
            var x= await db.polls.AddAsync(pool);
            await db.SaveChangesAsync();
            return (pool);
        }

        public async Task<bool> UpdateAsync(int id, Poll poll)
        {
            var po = await getByIdAsync(id);
            if (po is null)
                return false;
            else
            {
                po.Summary = poll.Summary;
                po.Title = poll.Title;
                return true;

            }
        }

        //    public bool Delete(int id)
        //    {

        //        var result=getById(id);
        //        if (result is null)
        //            return false;
        //        else
        //        {
        //            polls.Remove(result);
        //            return true;
        //        }
        //    }
        //}
    }
}
