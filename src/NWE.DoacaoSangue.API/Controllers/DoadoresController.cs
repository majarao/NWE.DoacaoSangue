using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Infra.Integrations.ViaCEP;

namespace NWE.DoacaoSangue.API.Controllers;

[Route("api/doadores")]
[ApiController]
public class DoadoresController(IViaCEPService cepService) : ControllerBase
{
    private IViaCEPService CEPService { get; } = cepService;

    [HttpGet("/cep/{cep}")]
    public async Task<IActionResult> GetCEP(string cep)
    {
        ViaCEPModel model = await CEPService.RecuperarEnderecoPeloCEPAsync(cep);

        if (model is null)
            return NotFound();

        return Ok(model);
    }
}
