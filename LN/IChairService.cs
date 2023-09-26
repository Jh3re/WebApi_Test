using Entities;
using DAL;

namespace LN
{
    public class IChairService
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
    }
}