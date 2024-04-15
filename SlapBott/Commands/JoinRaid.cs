namespace SlapBott.Core.Commands
{
    using Discord;
  
    using Discord.Interactions;
    using InteractionFramework;
    using SlapBott.Services.Contracts;
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


        [SlashCommand("joinraid", description: "Joins the raid", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinRaidAsync()
        {
          
            //  string msg = _raidService.JoinRaid( userid, channelId );
           
            await ReplyAsync(embed:BuilderReplies.DisplayRaidBoss(_raidService.RaidCheck(new object()))) ;

        }
    

    }
}
