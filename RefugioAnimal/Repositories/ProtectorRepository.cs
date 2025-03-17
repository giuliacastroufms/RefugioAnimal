using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Data;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Repositories
{
    public class DonorProtectorRepository
    {
        private readonly AnimalRefugeDbContext _context;

        public DonorProtectorRepository(AnimalRefugeDbContext context)
        {
            _context = context;
        }

        public async Task<List<DonorProtector>> GetAllAsync() =>
            await _context.DonorProtectors
                .Include(a => a.User)
                .ToListAsync();

        public async Task<DonorProtector?> GetByIdAsync(long id) =>
            await _context.DonorProtectors
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

        public async Task AddAsync(DonorProtector donorProtector)
        {
            _context.DonorProtectors.Add(donorProtector);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DonorProtector donorProtector)
        {
            _context.DonorProtectors.Update(donorProtector);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(long id)
        {
            return await _context.DonorProtectors.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task DeleteAsync(long id)
        {
            if (await _context.DonorProtectors.FindAsync(id) is DonorProtector donorProtector)
            {
                _context.DonorProtectors.Remove(donorProtector);
                await _context.SaveChangesAsync();
            }
        }
    }
}
