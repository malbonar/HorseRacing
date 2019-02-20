using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MBSoftware.HorseRacing.Core.DAL;
using MBSoftware.HorseRacing.Core.DataServices;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MBSoftware.HorseRacing.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddDbContext<AzureHorseRatingsDbContext>(options =>
            //    options.UseSqlServer(Configuration["ConnectionStrings:HorseRacingSqlServer"]));
            services.Configure<ConnectionStringConfig>(Configuration.GetSection("connectionStrings"));
            services.AddScoped<ITrainerJockeyFormLineProvider, TrainerJockeyFormDataService>();
            services.AddScoped<IDbContextFactory, DbContextProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
                        
            app.UseHttpsRedirection();
            app.UseMvc();
            Mapper.Initialize(cfg => cfg.CreateMap<TrainerJockeyComboFormWebEntities, TrainerJockeyFormLine>());
        }
    }
}
