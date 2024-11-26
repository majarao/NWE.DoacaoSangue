using MediatR;

namespace NWE.DoacaoSangue.Domain.Events.DoadorEvents;

public record NovoDoadorEvent(string NomeCompleto) : INotification;
