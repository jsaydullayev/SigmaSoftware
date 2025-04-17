using Microsoft.AspNetCore.Mvc;
using SigmaSoftware.Common.Models.CandidateModels;
using SigmaSoftware.Service.Extensions;
using SigmaSoftware.Service.Services.Contracts;

namespace SigmaSoftware.Api.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class CandidateController(ICandidateService candidateService) : Controller
{
    private readonly ICandidateService _candidateService = candidateService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var candidates = await _candidateService.GetAll();
        return Ok(candidates);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCandidateModel model)
    {
        var result = await _candidateService.Add(model);
        if(_candidateService.IsValid)
            return Ok(result);

        _candidateService.CopyToModel(ModelState);
        return BadRequest(ModelState);
    }
}
