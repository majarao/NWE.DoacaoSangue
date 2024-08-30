using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.API.Controllers;

[Route("api/doacoes")]
[ApiController]
public class DoacoesController(IDoacaoRepository repository) : ControllerBase
{
    private IDoacaoRepository Repository { get; } = repository;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() => Ok(await Repository.GetAllAsync());
}
