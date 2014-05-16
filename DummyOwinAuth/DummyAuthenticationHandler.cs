using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyOwinAuth
{
    // Created by the factory in the DummyAuthenticationMiddleware class.
    class DummyAuthenticationHandler : AuthenticationHandler<DummyAuthenticationOptions>
    {
        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode == 401)
            {
                var challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
                if (challenge == null)
                {
                    // Real implementations just return here, but I want to know if we ever get here.
                    throw new InvalidOperationException("Expected a challenge to be present");
                }

                var state = challenge.Properties;

                if (string.IsNullOrEmpty(state.RedirectUri))
                {
                    state.RedirectUri = Request.Uri.ToString();
                }

                Response.Redirect(Options.CallbackPath.Value + "?return=" + Uri.EscapeDataString(state.RedirectUri));
            }

            return Task.FromResult<object>(null);
        }

        public override async Task<bool> InvokeAsync()
        {
            // This is always invoked on each request. For passive middleware, only do anything if this is
            // for our callback path when the user is redirected back from the authentication provider.
            if(Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                var ticket = await AuthenticateAsync();

                if(ticket != null)
                {
                    Response.Redirect(ticket.Properties.RedirectUri);
                    return true;
                }
            }
            return false;
        }
    }
}
