using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ExtractImages.Middleware
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserSecurity _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserSecurity userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(nameof(SecurityConstants.xUsername))
                && !Request.Headers.ContainsKey(nameof(SecurityConstants.xPassword)))
                return AuthenticateResult.Fail("Missing Authorization Header");

            bool authResult = false;
            string username = string.Empty;
            string password = string.Empty;
            try
            {
                username = Request.Headers[nameof(SecurityConstants.xUsername)].ToString();
                password = Request.Headers[nameof(SecurityConstants.xPassword)].ToString();

                authResult = _userService.AuthenticateUser(username, password);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (!authResult)
                return AuthenticateResult.Fail("Failed to validate the username and password");

            var claims = new[] {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Name, username),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket); //Generate and pass a new authentication ticket for processing
        }
    }
}
