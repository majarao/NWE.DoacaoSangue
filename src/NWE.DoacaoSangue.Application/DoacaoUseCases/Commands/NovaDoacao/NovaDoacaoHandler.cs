using MediatR;
using NWE.DoacaoSangue.Application.Models;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;

public class NovaDoacaoHandler(IDoacaoRepository doacaoRepository, IDoadorRepository doadorRepository) : IRequestHandler<NovaDoacaoCommand, NovaDoacaoResut>
{
    private IDoacaoRepository DoacaoRepository { get; } = doacaoRepository;
    private IDoadorRepository DoadorRepository { get; } = doadorRepository;

    public async Task<NovaDoacaoResut> Handle(NovaDoacaoCommand request, CancellationToken cancellationToken)
    {
        Doacao doacao = new(DoadorRepository, DoacaoRepository, request.DoadorId, request.DataDoacao, request.QuantidadeML);
        doacao = await DoacaoRepository.CreateAsync(doacao);

        Doador? doador = await DoadorRepository.GetByIdAsync(doacao.DoadorId);
        DoadorModel doadorModel = new(doador!.NomeCompleto);

        NovaDoacaoResut resut = new(doacao.Id, doadorModel, doacao.DataDoacao, doacao.QuantidadeML);

        return resut;
    }
}
