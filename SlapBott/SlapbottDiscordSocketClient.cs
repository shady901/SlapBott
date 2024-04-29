﻿using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlapBott.Data;
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
using System.ComponentModel;
using SlapBott.Notifications;

// Here we can initialize the service that will register and execute our commands
//await serviceProvider.GetRequiredService<InteractionHandler>()
//.InitializeAsync();


namespace SlapBott
{
    internal class SlapbottDiscordSocketClient : DiscordSocketClient, IDisposable
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

            await RaidChecker();
            
            return this;

        }

        private Task RaidChecker()
        {

            TimerCallback callback = serviceProvider.GetService<RaidService>().RaidCheck;

            // Create a timer that ticks every hour
            TimeSpan interval = TimeSpan.FromHours(1);
            _timer = new Timer(callback, null, TimeSpan.Zero, interval);

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
