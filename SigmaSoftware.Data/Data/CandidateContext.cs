using Microsoft.EntityFrameworkCore;
using SigmaSoftware.Data.Entities;

namespace SigmaSoftware.Data.Data;

public class CandidateContext : DbContext
{
    DbSet<Candidate> Candidates { get; set; }
}
