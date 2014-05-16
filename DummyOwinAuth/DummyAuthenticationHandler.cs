using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyOwinAuth
{
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
    }
}
