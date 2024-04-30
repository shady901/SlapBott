
using Microsoft.Extensions.DependencyInjection;
using SlapBott.Services.Implmentations;

namespace SlapBott.Services
{
    public class Startup
    {


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<RaidService>();
            services.AddSingleton<PlayerCharacterService>();
            services.AddSingleton<RegionService>();
            services.AddSingleton<EnemyService>();
            services.AddSingleton<CombatStateService>();
            services.AddSingleton<CombatManager>();
            services.AddSingleton<ItemService>();
            services.AddSingleton<RegistrationService>();
            services.AddSingleton<SkillService>();
            services.AddSingleton<DiscordGuildService>();
        }
    }
}
