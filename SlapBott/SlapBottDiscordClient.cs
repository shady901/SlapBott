using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slapbott.Data;
using Discord.Interactions;
using InteractionFramework;
using SlapBott.Data.Repos;
using SlapBott.Services.Contracts;
using SlapBott.Services.Notifactions;
using SlapBott.Services.Implmentations;
using System;
using SlapBott.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

// Here we can initialize the service that will register and execute our commands
//await serviceProvider.GetRequiredService<InteractionHandler>()
//.InitializeAsync();


namespace SlapBott
{
    internal class SlapBottDiscordClient(IServiceProvider serviceProvider) : IDisposable
    {

        private Timer timer;

        private IMediator mediator;

        public async Task<DiscordSocketClient> StartAsync()
        {
            mediator = serviceProvider.GetRequiredService<IMediator>();
            var client = serviceProvider.GetRequiredService<DiscordSocketClient>();
            //var _handler = new RepliesHandler(serviceProvider.GetService<PlayerCharacterService>(), serviceProvider.GetService<RegistrationService>(), serviceProvider.GetService<SkillService>());

            client.Log += LogAsync;
            client.SlashCommandExecuted += Client_SlashCommandExecuted;
            client.SelectMenuExecuted += Client_SelectMenuExecuted;
            client.ModalSubmitted += Client_ModalSubmitted;


            // Bot token can be provided from the Configuration object we set up earlier
            await client.LoginAsync(TokenType.Bot, Properties.Resources.Token);
            await client.StartAsync();

            //TimerCallback callback = serviceProvider.GetService<RaidService>().RaidCheck;
            StartRaidCheck(TimeSpan.FromHours(int.Parse(Properties.Resources.RaidTimer)));
            //// Create a timer that ticks every hour
            
            //mediator.Publish(client);
            
            return client;

        }

        private void StartRaidCheck(TimeSpan timeSpan)
        {
            TimerCallback callback = serviceProvider.GetService<RaidService>().RaidCheck;

            timer = new Timer(callback, null, TimeSpan.Zero, timeSpan);

        }

        private Task Client_ModalSubmitted(SocketModal modal)
        {
            Console.WriteLine("Client_ModalSubmitted");
            //mediator.
            return Task.CompletedTask;
        }

        private Task Client_SelectMenuExecuted(SocketMessageComponent component)
        {
            Console.WriteLine("Client_SelectMenuExecuted");
            //mediator.
            return Task.CompletedTask;
        }

        private Task Client_SlashCommandExecuted(SocketSlashCommand command)
        {
            Console.WriteLine("Client_SlashCommandExecuted");
            //mediator.
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }

       
        public void Dispose()
        {
            timer.Dispose();
        }



        public static async Task<DiscordSocketClient> StartAsync(IServiceProvider serviceProvider)
        {
            var instance = new SlapBottDiscordClient(serviceProvider);

            var client = await instance.StartAsync();

            //Throw new ClientStartedEvent
            //await mediator.Publish(null, CancellationToken.None);

            return client;

        }



    }
}
