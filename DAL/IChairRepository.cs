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
        public async Task<IEnumerable<Chair>> GetAllChairsAsync()
        {
            return await _context.Chairs.ToListAsync();
        }
        public async Task<Chair> CreateChairAsync(Chair chair)
        {
            
            _context.Users.Add(chair);
            await _context.SaveChangesAsync();
            return chair;
        }
        public async Task<Chair> GetChairByIdAsync(int chairId)
        {
            var chair = await _context.Users.FindAsync(chairId);

            return chair;
        }
    }
}