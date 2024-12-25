using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Data;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Repositories
{
    public class AnimalRepository
    {
        private readonly AnimalRefugeDbContext _context;

        public AnimalRepository(AnimalRefugeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> GetAllAsync() =>
            await _context.Animals
                .Include(a => a.Breed)
                .Include(a => a.Photos)
                .ToListAsync();

        public async Task<Animal?> GetByIdAsync(long id) =>
            await _context.Animals
                .Include(a => a.Breed)
                .Include(a => a.Photos)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(long id)
        {
            return await _context.Animals.AnyAsync(a => a.Id == id);
        }

        public async Task DeleteAsync(long id)
        {
            if (await _context.Animals.FindAsync(id) is Animal animal)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
