using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ITalkService
    {
        Task<IEnumerable<Talk>> GetAllTalks(bool trackChange);
         
        void CreateTalk(TalkDtoForInsertion talkDto);
        Talk? GetOneTalk(int id, bool trackChange);
         
        void Complete(int id);

       // void SaveTalk(Talk talk);
        void DeleteOneTalk(int id);
        void UpdateOneTalk(TalkDtoForUpdate talk);
        TalkDtoForUpdate GetOneTalkForUpdate(int id, bool trackChanges);
    }
}
