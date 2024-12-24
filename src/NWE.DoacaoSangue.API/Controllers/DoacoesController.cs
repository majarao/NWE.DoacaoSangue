using MediatR;
using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;
using NWE.DoacaoSangue.Application.DoacaoUseCases.Querys.GetEstoque;
using NWE.DoacaoSangue.Domain.Models;

namespace NWE.DoacaoSangue.API.Controllers;

[Route("api/doacoes")]
[ApiController]
public class DoacoesController(IMediator mediator) : ControllerBase
{
    private IMediator Mediator { get; } = mediator;

    [HttpPost]
    public async Task<IActionResult> Post(NovaDoacaoCommand command)
    {
        NovaDoacaoResut result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("estoque")]
    public async Task<IActionResult> GetEstoque()
    {
        GetEstoqueQuery query = new();
        List<Estoque> result = await Mediator.Send(query);

        return Ok(result);
    }
}
