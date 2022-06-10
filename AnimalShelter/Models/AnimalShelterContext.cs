using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasData(
                    new Animal { AnimalId = 1, Type = "Dog", Name = "Spooky", Age = 2},
                    new Animal { AnimalId = 2, Type = "Dog", Name = "Alexa", Age = 3},
                    new Animal { AnimalId = 3, Type = "Dog", Name = "Beethoven", Age = 5},
                    new Animal { AnimalId = 4, Type = "Cat", Name = "Bella", Age = 1},
                    new Animal { AnimalId = 5, Type = "Cat", Name = "Blake", Age = 4}
                );
        }
    }
}