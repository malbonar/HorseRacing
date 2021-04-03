using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MBSoftware.HorseRacing.Core.Api.Middleware;
using MBSoftware.HorseRacing.Core.DataServices;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddResponseCaching();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://mbsoftwaresolutions.auth0.com/";
                    options.Audience = "https://horseracing/";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:trainerjockeystats",
                    policy => policy.Requirements.Add(
                        new HasScopeRequirement("read:trainerjockeystats", "https://mbsoftwaresolutions.auth0.com/")));
                options.AddPolicy("read:racecards",
                     policy => policy.Requirements.Add(
                         new HasScopeRequirement("read:racecards", "https://mbsoftwaresolutions.auth0.com/")));
            });

            // register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.Configure<ConnectionStringConfig>(Configuration.GetSection("connectionStrings"));
            services.AddScoped<ITrainerJockeyFormLineProvider, TrainerJockeyFormDataService>();
            services.AddScoped<IRaceMeetingProvider, RaceMeetingDataService>();
            services.AddScoped<IRaceCardProvider, RaceMeetingDataService>();
            services.AddScoped<IRaceResultsProvider, RaceMeetingResultDataService>();
            services.AddScoped<IHorsesForConditionsProvider, BettingAngulesDataService>();
            services.AddScoped<IDbContextFactory, DbContextProvider>();

            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(XmlCommentsFilePath);
            });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HorseRacing API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseAuthentication();
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/plain";
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        // log details
                    }
                    await context.Response.WriteAsync("Internal server error processing request").ConfigureAwait(false);
                });
            });
            app.UseMvc();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DAL.TrainerJockeyComboFormHorse, TrainerJockeyFormLineHorse>();
                cfg.CreateMap<DAL.TrainerJockeyComboForm, TrainerJockeyFormLine>()
                    .ForMember(dest => dest.TrainerJockeyComboFormHorse, act => act.MapFrom(src => src.TrainerJockeyComboFormHorse));
                cfg.CreateMap<DAL.RaceCardHorse, HorseRaceRunner>();
                cfg.CreateMap<DAL.RaceCard, RaceCard>()
                    .ForMember(dest => dest.Horses, act => act.MapFrom(src => src.RaceCardHorse));
                cfg.CreateMap<DAL.RaceCardHorseHistory, HorsePreviousRun>();
                cfg.CreateMap<DAL.HorsesForConditions, HorseForConditions>();
                cfg.CreateMap<DAL.RaceMeetingResult, RaceMeetingResult>();
                cfg.CreateMap<DAL.RaceResult, RaceResult>();
                cfg.CreateMap<DAL.RaceResultHorse, RaceResultHorse>();
            });
        }
    }
}
