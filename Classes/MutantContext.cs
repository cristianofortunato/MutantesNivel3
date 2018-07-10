using System;
using Microsoft.EntityFrameworkCore;


namespace Classes
{
    public class MutantContext : DbContext
    {
        public MutantContext(DbContextOptions<MutantContext> options) : base(options)
        {
        }

        public DbSet<Classes.Mutant> Mutants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes.Mutant>()
                        .Property(b => b._DNA);
        }
    }
}