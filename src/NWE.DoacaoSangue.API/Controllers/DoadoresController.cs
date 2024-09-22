using MediatR;
using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

namespace NWE.DoacaoSangue.API.Controllers;

[Route("api/doadores")]
[ApiController]
public class DoadoresController(IMediator mediator) : ControllerBase
{
    private IMediator Mediator { get; } = mediator;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        DoadorByIdQuery query = new(id);
        DoadorByIdResult result = await Mediator.Send(query);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{id:guid}/endereco")]
    public async Task<IActionResult> GetByIdComEndereco(Guid id)
    {
        DoadorByIdComEnderecoQuery query = new(id);
        DoadorByIdComEnderecoResult result = await Mediator.Send(query);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(NovoDoadorCommand command)
    {
        NovoDoadorResult result = await Mediator.Send(command);

        return Ok(result);
    }
}
