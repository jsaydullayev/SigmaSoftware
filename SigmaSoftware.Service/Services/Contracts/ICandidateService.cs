using SigmaSoftware.Common.Dtos;
using SigmaSoftware.Common.Models.CandidateModels;
using StatusGeneric;

namespace SigmaSoftware.Service.Services.Contracts;
public interface ICandidateService : IStatusGeneric
{
    Task<string> Add(AddCandidateModel model);
    Task<List<CandidateDto>> GetAll();
}
