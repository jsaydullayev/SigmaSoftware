using Microsoft.EntityFrameworkCore;
using SigmaSoftware.Data.Entities;

namespace SigmaSoftware.Data.Data;

public class CandidateContext : DbContext
{
    public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
    {
    }
    DbSet<Candidate> Candidates { get; set; }
}
