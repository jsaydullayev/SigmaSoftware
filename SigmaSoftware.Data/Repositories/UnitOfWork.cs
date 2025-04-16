using SigmaSoftware.Data.Data;
using SigmaSoftware.Data.Entities;
using SigmaSoftware.Data.Repositories.Contracts;

namespace SigmaSoftware.Data.Repositories;
public class UnitOfWork(CandidateContext context) : IUnitOfWork
{
    public IBaseRepository<Candidate> CandidateRepository() => _candidateContext ?? new BaseRepository<Candidate>(context);

    private IBaseRepository<Candidate> _candidateContext { get; }
}
