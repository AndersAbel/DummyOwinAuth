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
                Response.Redirect(Options.CallbackPath.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
