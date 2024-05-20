namespace SlapBott.Core
{
    using Discord;
    using Discord.WebSocket;

    using Microsoft.Extensions.DependencyInjection;
    using SlapBott.Data;
    using Discord.Interactions;
    using InteractionFramework;
    using System;
    using Microsoft.EntityFrameworkCore;


    public class Program
    {

        private static IServiceProvider _servicesProvider;

        private static readonly DiscordSocketConfig _socketConfig = new()
        {
            GatewayIntents = GatewayIntents.MessageContent | GatewayIntents.GuildMembers,
            AlwaysDownloadUsers = true,
        };

   
        public static async Task Main(string[] args)
        {



            //_configuration = new ConfigurationBuilder()
            //    .AddEnvironmentVariables(prefix: "DC_")
            //    .AddJsonFile("appsettings.json", optional: true)
            //    .Build();

            IServiceCollection _services = new ServiceCollection()
            //    .AddSingleton(_configuration)
                .AddSingleton(_socketConfig)
                .AddSingleton<SlapbottDiscordSocketClient>()
                .AddSingleton(x => new InteractionService(x.GetRequiredService<SlapbottDiscordSocketClient>()))
                .AddSingleton((x) => {
                    return new InteractionHandler(
                        x.GetRequiredService<SlapbottDiscordSocketClient>(),
                        x.GetRequiredService<InteractionService>(),
                        x
                    );
                });

            Services.Startup.ConfigureServices(_services);
            Startup.ConfigureServices(_services, Properties.Resources.DbConnection);



            _services.AddDbContext<SlapbottDbContext>(options => options.UseSqlite(Properties.Resources.DbConnection));

            _services.AddMediatR(options =>
            {
                // Configure MediatR options here
                // For example, you can specify service lifetime, behavior, etc.
                options.RegisterServicesFromAssembly(typeof(Program).Assembly);

            });


            _servicesProvider = _services.BuildServiceProvider();

            await _servicesProvider
                    .GetRequiredService<InteractionHandler>()
                    .InitializeAsync();


            var discord_client = _servicesProvider.GetRequiredService<SlapbottDiscordSocketClient>();

            await discord_client.StartAsync(TokenType.Bot, Properties.Resources.Token);

            //var discordclient = await SlapBottDiscordClient.StartAsync(_servicesProvider);

            await Task.Delay(Timeout.Infinite);


            // var client = _servicesProvider.GetRequiredService<DiscordSocketClient>();
            //_handler = new RepliesHandler(_servicesProvider.GetService<PlayerCharacterService>(), _servicesProvider.GetService<RegistrationService>(),_servicesProvider.GetService<SkillService>());

            // client.Log += LogAsync;
            // client.SlashCommandExecuted += Client_SlashCommandExecuted;
            // client.SelectMenuExecuted += Client_SelectMenuExecuted;
            // client.ModalSubmitted += Client_ModalSubmitted;

            //     // Here we can initialize the service that will register and execute our commands
            //     await _servicesProvider.GetRequiredService<InteractionHandler>()
            //     .InitializeAsync();

            // // Bot token can be provided from the Configuration object we set up earlier
            // await client.LoginAsync(TokenType.Bot, Properties.Resources.Token);
            // await client.StartAsync();

            // TimerCallback callback = _servicesProvider.GetService<RaidService>().RaidCheck;

            // // Create a timer that ticks every hour
            // TimeSpan interval = TimeSpan.FromHours(1);
            // Timer timer = new Timer(callback, null, TimeSpan.Zero, interval);

            // // Never quit the program until manually forced to.
            // await Task.Delay(Timeout.Infinite);
            // timer.Dispose();
        }


        //private static Task Client_SelectMenuExecuted(SocketMessageComponent arg)
        //{
        //    Console.WriteLine(arg.Data.CustomId);
        //    _handler.HandleSubmittedSelectMenu(arg);
        //    return Task.CompletedTask;
        //}

        //private static Task Client_ModalSubmitted(SocketModal modal)
        //{
        //    Console.WriteLine(modal.Data.CustomId);
        //    _handler.HandleSubmittedModal(modal);
        //     return Task.CompletedTask;

        //}

        //private static Task Client_SlashCommandExecuted(SocketSlashCommand arg)
        //{
        //    Console.WriteLine(arg.Data.Name);
        //    return Task.CompletedTask;
        //}

        //private static async Task LogAsync(LogMessage message)
        //    => Console.WriteLine(message.ToString());

        //private static void ConfigureServices(IServiceCollection services)
        //{
        //    // Configure services from DAL project
        //    Startup.ConfigureServices(services, Properties.Resources.DbConnection);
        //}

    }


}




