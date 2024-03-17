using Microsoft.EntityFrameworkCore;

namespace ChessAPIs.Models
{
    public class ChessContext : DbContext
    {
        public ChessContext(DbContextOptions<ChessContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professional> Professionals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student entity
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentID);

            // Configure Professional entity
            modelBuilder.Entity<Professional>()
                .HasKey(p => p.ProfessionalID);
        }
    }
}
