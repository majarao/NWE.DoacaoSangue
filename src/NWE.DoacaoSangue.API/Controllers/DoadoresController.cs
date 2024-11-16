using MediatR;
using Microsoft.AspNetCore.Mvc;
using NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;
using NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoacoesDoDoador;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;
using NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorGetAll;

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

    [HttpGet("{id:guid}/doacoes")]
    public async Task<IActionResult> GetDoacoes(Guid id)
    {
        DoacoesDoDoadorQuery query = new(id);
        DoacoesDoDoadorResult? result = await Mediator.Send(query);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        DoadorGetAllQuery query = new();
        List<DoadorGetAllResult>? result = await Mediator.Send(query);

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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, AtualizaDoadorCommand command)
    {
        DoadorByIdQuery query = new(id);
        DoadorByIdResult doador = await Mediator.Send(query);

        if (doador is null)
            return NotFound();

        if (id != command.Id)
            return BadRequest();

        AtualizaDoadorResult result = await Mediator.Send(command);

        return Ok(result);
    }
}
