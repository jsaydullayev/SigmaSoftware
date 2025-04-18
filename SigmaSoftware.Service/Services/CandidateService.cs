using SigmaSoftware.Common.Dtos;
using SigmaSoftware.Common.Models.CandidateModels;
using SigmaSoftware.Data.Entities;
using SigmaSoftware.Data.Repositories.Contracts;
using SigmaSoftware.Service.Extensions;
using SigmaSoftware.Service.Services.Contracts;
using StatusGeneric;

namespace SigmaSoftware.Service.Services;
public class CandidateService(IUnitOfWork unitOfWork) : StatusGenericHandler, ICandidateService
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<string> Upsert(AddCandidateModel model)
    {
        var check = await CheckEmail(model.Email);
        if (check is not null)
        {
            await _unitOfWork.CandidateRepository().Delete(check);
            await _unitOfWork.CandidateRepository().Add(model.MapToEntity<Candidate, AddCandidateModel>());
            await _unitOfWork.CandidateRepository().SaveChanges();
            return "Your email updated";
        }

        check = model.MapToEntity<Candidate, AddCandidateModel>();
        await _unitOfWork.CandidateRepository().Update(check);
        await _unitOfWork.CandidateRepository().SaveChanges();
        return "successfully";
    }

    public async Task<List<CandidateDto>> GetAll()
    {
        var candidates = (await _unitOfWork.CandidateRepository().GetAll()).ToList();
        return candidates.MapToDtos<Candidate, CandidateDto>();
    }

    private async Task<Candidate?> CheckEmail(string email)
    {
        var entity = (await _unitOfWork.CandidateRepository().GetAll()).FirstOrDefault(x => x.Email == email);
        if (entity is null)
            return null;

        return entity;
    }
}
