using MediatR;

namespace NWE.DoacaoSangue.Domain.Events.DoadorEvents;

public record DoadorAtualizadoEvent(string Email) : INotification;
