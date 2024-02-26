namespace SlapBott.Core.Commands
{
    using Discord;
    using Discord.Commands;
    using SlapBott.Services.Contracts;

    public class JoinRaid : ModuleBase<SocketCommandContext>  
    {
        private readonly IRaidService _raidService;


        public JoinRaid(IRaidService raidService)
        {
            _raidService = raidService;
        }


        [Command("joinraid", RunMode = RunMode.Async)]
        public async Task JoinRaidAsync()
        {
            var userid = Context.User.Id;
            var channelId = Context.Channel.Id;    
            
            string msg = _raidService.JoinRaid( userid, channelId );
            
            await ReplyAsync(msg, false) ;

        }
    

    }
}
