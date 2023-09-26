using Entities;
using Tools;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IChairRepository
    {
        Task<IEnumerable<Chair>> GetAllChairsAsync();
        Task<Chair> CreateChairAsync(Chair chair);
        Task<Chair> GetChairByIdAsync(int chairId);
        Task<Chair> PutChairByIdAsync(int chairId, Chair chair);
        Task<Chair> DeleteChairByIdAsync(int chairId);
    }
    public class ChairRepository : IChairRepository
    {
        private readonly DataContext _context;

        public ChairRepository(DataContext context)
        {
            _context = context;
        }
    }
}