namespace Prome.Viaticos.Server.Api.Users.Security
{
    using System;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration configuration)
            : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            bool isValid;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                isValid = this.IsValid(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (!isValid)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, "ApiUser"),
            new Claim(ClaimTypes.Name, "ApiUser")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        private bool IsValid(string userName, string password)
        {
            var apiUser = _configuration.GetSection("Api")["apiUser"];
            var apiUserPassword = _configuration.GetSection("Api")["apiUserPassword"];
            return apiUser == userName && apiUserPassword == password;
        }
    }
}
