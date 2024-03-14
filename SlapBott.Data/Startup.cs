﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SlapBott.Data;
namespace Slapbott.Data
{

    public class Startup
    {


        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SlapbottDbContext>(options =>
                options.UseSqlite(connectionString));
            
          
            // Add other services as needed
        }
    }

}