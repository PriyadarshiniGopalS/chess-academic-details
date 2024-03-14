using Microsoft.EntityFrameworkCore;

namespace ChessAPIs.Models
{
    public class ChessContext : DbContext
    {
        public ChessContext(DbContextOptions<ChessContext> options) : base(options)
        {
        }

        public DbSet<EnrollDetails> EnrollDetails { get; set; } = null;
    }
}
