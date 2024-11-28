using MediatR;

namespace NWE.DoacaoSangue.Domain.Events.DoadorEvents;

public class DoadorEventHandler :
    INotificationHandler<DoadorCriadoEvent>,
    INotificationHandler<DoadorAtualizadoEvent>
{
    public Task Handle(DoadorCriadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Um novo doador foi cadastrado, diga olá para {notification.NomeCompleto}!");
        }, cancellationToken);
    }

    public Task Handle(DoadorAtualizadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Doador do e-mail {notification.Email} foi atualizado!");
        }, cancellationToken);
    }
}
