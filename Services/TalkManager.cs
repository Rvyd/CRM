using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using AutoMapper;

namespace Services
{
    public class TalkManager : ITalkService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TalkManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void Complete(int id)
        {
            _manager.Talk.Complete(id);
            _manager.Save();
        }

        public void CreateTalk(TalkDtoForInsertion talkDto)
        {
            var talk = _mapper.Map<Talk>(talkDto);
            _manager.Talk.Create(talk);
            _manager.Save();
        }

        public void DeleteOneTalk(int id)
        {
            Talk talk = GetOneTalk(id, false);
            if (talk is not null)
            {
                _manager.Talk.DeleteOneTalk(talk);
                _manager.Save();
            }
        }

        public async Task<IEnumerable<Talk>> GetAllTalks(bool trackChange)
        {
            return await _manager.Talk.GetAllTalks(trackChange);
        }

        public Talk? GetOneTalk(int id, bool trackChange)
        {
            return _manager.Talk.GetOneTalk(id, false);
        }

        public TalkDtoForUpdate GetOneTalkForUpdate(int id, bool trackChanges)
        {
            var talk=GetOneTalk(id,trackChanges);
            var talkDto=_mapper.Map<TalkDtoForUpdate>(talk);
            return talkDto;
        }

        public void UpdateOneTalk(TalkDtoForUpdate talkDto)
        {
            var entity=_mapper.Map<Talk>(talkDto);
            _manager.Talk.UpdateOneTalk(entity);
            _manager.Save();
        }






        /* public TalkDtoForUpdate GetOneTalkForUpdate(int id, bool trackChanges)
         {
             var talk=GetOneTalk(id,trackChanges);
             var talkDto=_mapper.Map<TalkDtoForUpdate>(talk);
             return talkDto;
         }*/

        /* public void SaveTalk(Talk talk)
         {
             _manager.Save();
         }*/


    }
}
