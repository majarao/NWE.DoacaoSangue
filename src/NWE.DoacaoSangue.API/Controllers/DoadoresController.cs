using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.API.Controllers;

[Route("api/doadores")]
[ApiController]
public class DoadoresController(ICEPService cepService) : ControllerBase
{
    private ICEPService CEPService { get; } = cepService;

    [HttpGet("/cep/{cep}")]
    public async Task<IActionResult> GetCEP(string cep)
    {
        CEPModel model = await CEPService.RecuperarEnderecoPeloCEPAsync(cep);

        if (model is null)
            return NotFound();

        return Ok(model);
    }
}
