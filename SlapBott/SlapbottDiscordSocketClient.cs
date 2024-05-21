using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using SlapBott.Services.Implmentations;
using MediatR;
using SlapBott.Notifications;

// Here we can initialize the service that will register and execute our commands
//await serviceProvider.GetRequiredService<InteractionHandler>()
//.InitializeAsync();


namespace SlapBott
{
    public class SlapbottDiscordSocketClient : DiscordSocketClient, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMediator _mediator;
        private Timer _timer ;
        public SlapbottDiscordSocketClient(IServiceProvider serviceProvider, IMediator mediator)
        {
            Log += LogAsync;
            SlashCommandExecuted += Client_SlashCommandExecuted;
            SelectMenuExecuted += Client_SelectMenuExecuted;
            ModalSubmitted += Client_ModalSubmitted;
            this.serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        public async Task<SlapbottDiscordSocketClient> StartAsync(TokenType token,string client_token)
        {

            
            await LoginAsync(token, client_token);
            await StartAsync();
          
            Ready += SlapbottDiscordSocketClient_Ready;
            return this;

        }

        private async Task SlapbottDiscordSocketClient_Ready()
        {
            await RaidChecker();          
        }

        private Task RaidChecker()
        {
            TimerCallback callback = serviceProvider.GetService<RaidService>().RaidCheck;
            TimeSpan interval = TimeSpan.FromDays(1);

            // Delay the first call to RaidCheck by the interval
            TimeSpan dueTime = interval;

            _timer = new Timer(callback, null, dueTime, interval);

            return Task.CompletedTask;

        }

        private Task Client_ModalSubmitted(SocketModal modal)
        {
            Console.WriteLine($"Client_ModalSubmitted: {modal.Data.CustomId}");
            //mediator.RepliesHandler
            _mediator.Publish(new ModelSubmitted(modal));
            return Task.CompletedTask;
        }

        private Task Client_SelectMenuExecuted(SocketMessageComponent component)
        {
            Console.WriteLine($"Client_SelectMenuExecuted: {component.Data.CustomId}");
            _mediator.Publish(new SelectMenuExecuted(component));
            return Task.CompletedTask;
        }

        private Task Client_SlashCommandExecuted(SocketSlashCommand command)
        {
            Console.WriteLine(command.CommandName);           
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }

       
        public void Dispose()
        {
           _timer.Dispose();
        }


    }
}
