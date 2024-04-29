

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SlapBott.Data.Repos;
namespace SlapBott.Data
{

    public class Startup
    {


        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            if (connectionString != string.Empty)
            {
                services.AddDbContext<SlapbottDbContext>(options => {
                        options.UseSqlite(connectionString);
                    },ServiceLifetime.Singleton

                );
            }

            services.AddSingleton<SkillRepo>();
            services.AddSingleton<RegistrationRepositry>();
            services.AddSingleton<PlayerCharacterRepositry>();
            services.AddSingleton<CombatStateRepositry>();
            services.AddSingleton<EnemyRepositry>();
            services.AddSingleton<EnemyTemplateRepo>();
            services.AddSingleton<RegionRepo>();
            services.AddSingleton<EnemyStateRepo>();
            services.AddSingleton<PlayerStateRepo>();
            // Add other services as needed
        }
    }

}