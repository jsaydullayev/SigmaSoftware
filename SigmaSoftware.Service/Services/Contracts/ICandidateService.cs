using SigmaSoftware.Common.Dtos;
using SigmaSoftware.Common.Models.CandidateModels;
using StatusGeneric;

namespace SigmaSoftware.Service.Services.Contracts;
public interface ICandidateService : IStatusGeneric
{
    Task<string> Upsert(AddCandidateModel model);
    Task<List<CandidateDto>> GetAll();
}
