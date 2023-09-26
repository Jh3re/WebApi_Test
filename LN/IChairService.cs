using Entities;
using DAL;

namespace LN
{
    public interface IChairService
    {
        Task<IEnumerable<Chair>> GetAllChairsAsync();
        Task<Chair> CreateChairAsync(Chair chair);
        Task<Chair> GetChairByIdAsync(int chairId);
        Task<Chair> PutChairByIdAsync(int chairId, Chair chair);
        Task<Chair> DeleteChairByIdAsync(int chairId);
    }

    public class ChairService: IChairService {
        private readonly IChairRepository _chairRepository;

        public ChairService(IChairRepository chairRepository)
        {
            _chairRepository = chairRepository;
        }
        public async Task<IEnumerable<Chair>> GetAllChairsAsync()
        {
            return await _chairRepository.GetAllChairsAsync();
        }
        public async Task<Chair> CreateChairAsync(Chair chair)
        {
            var newChair = await _chairRepository.CreateChairAsync(chair);
            return newChair;
        }
        public async Task<Chair> GetChairByIdAsync(int chairId)
        {
            return await _chairRepository.GetChairByIdAsync(chairId);
        }
        public async Task<Chair> PutChairByIdAsync(int chairId, Chair chair)
        {
            return await _chairRepository.PutChairByIdAsync(chairId,chair);
        }
        public async Task<Chair> DeleteChairByIdAsync(int chairId)  
        {
            return await _chairRepository.DeleteChairByIdAsync(chairId);
        }
    }
}