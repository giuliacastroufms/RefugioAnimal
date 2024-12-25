using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Data
{
    public class AnimalRefugeDbContext : DbContext
    {
        public AnimalRefugeDbContext(DbContextOptions<AnimalRefugeDbContext> options) : base(options) { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<AnimalPhoto> AnimalPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.HasOne(e => e.Breed)
                    .WithMany()
                    .HasForeignKey(e => e.BreedId);

                entity.HasMany(e => e.Photos)
                    .WithOne()
                    .HasForeignKey(p => p.AnimalId);
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<AnimalPhoto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Photo)
                    .IsRequired();
            });
        }
    }

}
