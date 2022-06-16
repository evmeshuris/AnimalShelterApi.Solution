using Microsoft.EntityFrameworkCore;

namespace AnimalShelter
{
    public partial class shelterContext : DbContext
    {
        public shelterContext()
        {
        }

        public shelterContext(DbContextOptions<shelterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shelter;uid=root;password=epicodus", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Type).HasColumnType("bit(1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
