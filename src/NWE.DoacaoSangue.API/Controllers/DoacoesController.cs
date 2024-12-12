using MediatR;
using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;

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
}
