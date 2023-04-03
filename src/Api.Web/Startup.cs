using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Prome.Viaticos.Server.Api.Web.Jobs;
using Prome.Viaticos.Server.Bootstrapper;
using Quartz;
using Quartz.Spi;
using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Google.Apis.Auth.AspNetCore3;

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
            //services.AddAuthentication("OAuth")
            //    .AddJwtBearer("OAuth", config => {
            //        var secretBytes = Encoding.UTF8.GetBytes(Configuration["AAD:Secrets"]);
            //        var key = new SymmetricSecurityKey(secretBytes);

            //        config.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            IssuerSigningKey = key
            //        };
            //    });

            //services.AddControllersWithViews();
            //services.AddSwaggerDocument();

            services.AddScoped<IJobFactory, FtpQuartzJobFactory>();
            services.AddTransient<FtpJob>();
            //// Add our job
            services.AddScoped<IJob, FtpJob>();

            services.AddBootstrapper(Configuration);


            services.AddCors();

            //services.AddAuthentication("OAuth")
            //    .AddJwtBearer("OAuth", config =>
            //    {
            //        var secretBytes = Encoding.UTF8.GetBytes(Configuration["AAD:Secrets"]);
            //        var key = new SymmetricSecurityKey(secretBytes);

            //        config.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidIssuer = Configuration["AAD:Issuer"],
            //            ValidAudience = Configuration["AAD:Audience"],
            //            IssuerSigningKey = key
            //        };
            //    });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //    options.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            //})
            //    .AddCookie()
            //    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            //    {
            //        options.ClientId = Configuration["Authentication:Google:ClientId"];
            //        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    });

            //services
            //    .AddAuthentication(o =>
            //    {
            //        // This forces challenge results to be handled by Google OpenID Handler, so there's no
            //        // need to add an AccountController that emits challenges for Login.
            //        o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            //        // This forces forbid results to be handled by Google OpenID Handler, which checks if
            //        // extra scopes are required and does automatic incremental auth.
            //        o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            //        // Default scheme that will handle everything else.
            //        // Once a user is authenticated, the OAuth2 token info is stored in cookies.
            //        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    })
            //    .AddCookie()
            //    .AddGoogleOpenIdConnect(options =>
            //    {
            //        options.ClientId = Configuration["Authentication:Google:ClientId"];
            //        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    });

            services.AddControllersWithViews();

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

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var jobFactory = (IServiceProvider)app.ApplicationServices.GetService(typeof(IServiceProvider));
            JobSchedule.StartAsync(jobFactory);
        }
    }
}
