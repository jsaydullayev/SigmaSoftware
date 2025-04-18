using Microsoft.EntityFrameworkCore;
using SigmaSoftware.Data.Entities;

namespace SigmaSoftware.Data.Data;

public class CandidateContext : DbContext
{
    public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.HasDefaultSchema("my");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Candidate> Candidates { get; set; }
}
