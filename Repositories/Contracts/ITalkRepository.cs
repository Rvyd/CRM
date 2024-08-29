using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITalkRepository: IRepositoryBase<Talk>
    {
        Task<IEnumerable<Talk>> GetAllTalks (bool trackChange);

        Talk GetOneTalk(int id, bool trackChange);
         
        void CreateTalk(Talk talk);
        void Complete(int id);

       // void SaveTalk(Talk talk);
        void DeleteOneTalk(Talk talk);
        void UpdateOneTalk(Talk entity);
         Task<int> GetTalkCountByStatusAsync(string state);

         Task<List<Talk>> GetTalksByStartDateAsync(DateOnly startDate);
    }
}
