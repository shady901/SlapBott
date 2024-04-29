namespace SlapBott.Core.Commands
{
    using Discord;
  
    using Discord.Interactions;
    using InteractionFramework;
    using SlapBott.Services.Contracts;
    using SlapBott.Services.Dtos;
    using SlapBott.Services.Implmentations;

    public class JoinRaid : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly RaidService _raidService;
        private InteractionHandler _handler;
        public InteractionService Commands { get; set; }

        public JoinRaid(RaidService raidService)
        {
            _raidService = raidService;
        }


        [SlashCommand("raidcheck", description: "temp command to simulate raidcheck process", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinRaidAsync()
        {

            //  string msg = _raidService.JoinRaid( userid, channelId );
            _raidService.RaidCheck(null);
            await RespondAsync("RaidCheck") ;

        }
    

    }
}
