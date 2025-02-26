using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Data
{
    public class AnimalRefugeDbContext : IdentityDbContext<User>
    {
        public AnimalRefugeDbContext(DbContextOptions<AnimalRefugeDbContext> options) : base(options) { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<AnimalPhoto> AnimalPhotos { get; set; }
        public DbSet<AdoptionType> AdoptionTypes { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.ToTable("Users");
            });

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

            modelBuilder.Entity<Adoption>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired();

                //entity.HasOne(e => e.User)
                //    .WithMany()
                //    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Animal)
                    .WithMany()
                    .HasForeignKey(e => e.AnimalId);

                entity.HasOne(e => e.AdoptionType)
                    .WithMany()
                    .HasForeignKey(e => e.AdoptionTypeId);
            });

            modelBuilder.Entity<AdoptionType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                    .IsRequired();
            });
        }
    }

}
