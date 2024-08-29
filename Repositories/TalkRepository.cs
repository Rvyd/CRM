using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class TalkRepository : RepositoryBase<Talk>, ITalkRepository
    {

        public TalkRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Talk>> GetAllTalks(bool trackChange) => FindAll(trackChange);

        public Talk? GetOneTalk(int id, bool trackChange)
        {
            return FinByCondition(p => p.TalkId.Equals(id), false);
        }

        public void Complete(int id)
        {

        }

        /*  public void SaveTalk(Talk talk)
          {
              _context.Talks.Add(talk);
              _context.SaveChanges();
          }*/

        public void CreateTalk(Talk talk) => Create(talk);

        public void DeleteOneTalk(Talk talk) => Remove(talk);

        public void UpdateOneTalk(Talk entity)
        {
            _context.Talks.Update(entity);
        }

        public async Task<int> GetTalkCountByStatusAsync(string state)
        {
            return await _context.Talks.CountAsync(t => t.State == state);
        }
        public async Task<List<Talk>> GetTalksByStartDateAsync(DateOnly startDate) //tarihe göre görüşme getirme
        {
            return await _context.Talks
                .Where(t => t.StartDate.Equals(startDate))
                .ToListAsync();
        } 


    }
}
