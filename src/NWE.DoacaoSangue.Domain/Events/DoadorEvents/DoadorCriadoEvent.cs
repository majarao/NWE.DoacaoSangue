using MediatR;

namespace NWE.DoacaoSangue.Domain.Events.DoadorEvents;

public record DoadorCriadoEvent(string NomeCompleto) : INotification;
