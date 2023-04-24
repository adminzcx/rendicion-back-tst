namespace Prome.Viaticos.Server.Api.Users
{
    using FluentValidation;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using NSwag;
    using NSwag.Generation.Processors.Security;
    using Prome.Viaticos.Server.Api.Users.Security;
    using Prome.Viaticos.Server.Bootstrapper;
    using System;
    using System.Net;

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
            services.AddBootstrapper(Configuration);
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerDocument(configure =>
            {
                configure.AddSecurity("Basic", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.Basic,
                    Name = "Basic",
                    In = OpenApiSecurityApiKeyLocation.Header
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Basic"));
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
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
        }
    }
}
