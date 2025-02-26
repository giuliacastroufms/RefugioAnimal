using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Data;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Repositories
{
    public class AdoptionRepository
    {
        private readonly AnimalRefugeDbContext _context;
        public AdoptionRepository(AnimalRefugeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Adoption>> GetAllAsync() =>
            await _context.Adoptions
                //.Include(a => a.User)
                .Include(a => a.Animal)
                .Include(a => a.AdoptionType)
                .ToListAsync();

        public async Task<Adoption?> GetByIdAsync(long id) =>
            await _context.Adoptions
                //.Include(a => a.User)
                .Include(a => a.Animal)
                .Include(a => a.AdoptionType)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

        public async Task AddAsync(Adoption adoption)
        {
            _context.Adoptions.Add(adoption);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Adoption adoption)
        {
            _context.Adoptions.Update(adoption);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(long id)
        {
            return await _context.Adoptions.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task DeleteAsync(long id)
        {
            if (await _context.Adoptions.FindAsync(id) is Adoption adoption)
            {
                _context.Adoptions.Remove(adoption);
                await _context.SaveChangesAsync();
            }
        }
    }
}
