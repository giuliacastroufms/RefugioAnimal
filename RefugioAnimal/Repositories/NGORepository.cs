using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Data;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Repositories
{
    public class NGORepository
    {
        private readonly AnimalRefugeDbContext _context;

        public NGORepository(AnimalRefugeDbContext context)
        {
            _context = context;
        }

        public async Task<List<NGO>> GetAllAsync() =>
            await _context.NGOs
                .Include(a => a.User)
                .ToListAsync();

        public async Task<NGO?> GetByIdAsync(long id) =>
            await _context.NGOs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

        public async Task AddAsync(NGO ngo)
        {
            _context.NGOs.Add(ngo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NGO ngo)
        {
            _context.NGOs.Update(ngo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(long id)
        {
            return await _context.NGOs.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task DeleteAsync(long id)
        {
            if (await _context.NGOs.FindAsync(id) is NGO ngo)
            {
                _context.NGOs.Remove(ngo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
