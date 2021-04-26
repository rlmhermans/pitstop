using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Pitstop.Infrastructure.Messaging;

class CustomerManager : IHostedService, IMessageHandlerCallback
{
    private IMessageHandler _messageHandler;

    public CustomerManager(IMessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
    }

    public async Task<bool> HandleMessageAsync(string messageType, string message)
    {
        if (messageType.Equals("CustomerRegistered"))
        {
            System.Console.WriteLine(message);
        }

        return true;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageHandler.Start(this);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _messageHandler.Stop();
        return Task.CompletedTask;
    }
}