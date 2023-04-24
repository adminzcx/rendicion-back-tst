using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Prome.Viaticos.Server.Api.Web.Jobs;
using Prome.Viaticos.Server.Bootstrapper;
using Quartz;
using Quartz.Spi;
using System;
using System.Net;


namespace Prome.Viaticos.Server.Api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<IJobFactory, FtpQuartzJobFactory>();
            services.AddTransient<FtpJob>();
            //// Add our job
            services.AddScoped<IJob, FtpJob>();

            services.AddBootstrapper(Configuration);


            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                           .AddJwtBearer(opt =>
                           {
                               opt.Audience = Configuration["AAD:Audience"];
                               opt.Authority = $"{Configuration["AAD:Instance"]}{Configuration["AAD:TenantId"]}";

                               opt.TokenValidationParameters = new TokenValidationParameters
                               {
                                   ValidIssuer = Configuration["AAD:Issuer"],
                                   ValidAudience = Configuration["AAD:Audience"],
                                   ValidateIssuer = true,
                                   ValidateAudience = true,
                                   ValidateLifetime = true,
                                   ValidateIssuerSigningKey = true,
                                   RequireExpirationTime = false
                               };
                           });

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var result = JsonConvert.SerializeObject(new { error = exception.Message });

                AppStaticLog.Fatal(exception, result);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (exception is ValidationException) context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                if (exception is ArgumentException) context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }));

            app.UseRequestLogging();
            app.UseHttpsRedirection();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var jobFactory = (IServiceProvider)app.ApplicationServices.GetService(typeof(IServiceProvider));
            JobSchedule.StartAsync(jobFactory);
        }
    }
}
