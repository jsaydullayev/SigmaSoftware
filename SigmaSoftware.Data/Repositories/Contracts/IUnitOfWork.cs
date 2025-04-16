using SigmaSoftware.Data.Entities;

namespace SigmaSoftware.Data.Repositories.Contracts;
public interface IUnitOfWork
{
    IBaseRepository<Candidate> CandidateRepository();
}
