using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using ElsaWorkFlowWithSqlDataBase.Activities;
using ElsaWorkFlowWithSqlDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaWorkFlowWithSqlDataBase
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ElsaDbContext>(ServiceLifetime.Transient);

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var elsaSection = Configuration.GetSection("Elsa");
            services
               .AddElsa(elsa => elsa
               .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(Configuration.GetConnectionString("DefultConnection")))
                   .AddConsoleActivities()
                   .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                   .AddEmailActivities(elsaSection.GetSection("Smtp").Bind)
                   .AddQuartzTemporalActivities()
                   .AddWorkflowsFrom<Startup>()
                   .AddActivity<CreateOrder>()
                   .AddActivity<ReviewDocument>()
               );

            services.AddElsaApiEndpoints();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseStaticFiles()
                .UseHttpActivities()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapFallbackToPage("/_Host");
                });
        }
    }
    }

