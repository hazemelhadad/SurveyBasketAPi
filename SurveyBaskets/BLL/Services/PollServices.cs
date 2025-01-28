
using SurveyBaskets.DAL.Persistence;

namespace SurveyBackets.BLL.Services
{
    public class PollServices(ApplicationDBContext _db) : IPollServices
    {
        private readonly ApplicationDBContext db = _db;

        // .......AsNoTracking()  tell him that i will not make any edit in the retrived data  and make entity frame work not tracking the changes happened to this model
        public async Task<IEnumerable<Poll>> GetAllAsync() =>
            await db.polls.AsNoTracking().ToListAsync();

        public async Task<Poll?> getByIdAsync(int id,CancellationToken cancellationToken) =>
            await db.polls.FindAsync(id,cancellationToken);
            

        public async Task<Poll?> AddNewAsync(Poll pool,CancellationToken cancellationToken=default)
        {
            var x= await db.polls.AddAsync(pool,cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
            return (pool);
        }

        public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken=default)
        {
            var po = await getByIdAsync(id,cancellationToken);
            if (po is null)
                return false;
            else
            {
                po.Title = poll.Title;
                po.Summary = poll.Summary;
                po.IsPublished = poll.IsPublished;
                po.StartsAt = poll.StartsAt;    
                po.EndsAt = poll.EndsAt;
                await db.SaveChangesAsync(cancellationToken);

                return true;

            }
        }

        public async Task <bool> DeleteAsync(int id,CancellationToken cancellationToken)
        {

            var result = await getByIdAsync(id,cancellationToken);
            if (result is null)
                return false;
            else
            {
                db.Remove(result);
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}

