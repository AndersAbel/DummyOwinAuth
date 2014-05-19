using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace DummyOwinAuth
{
    // One instance is created when the application starts.
    class DummyAuthenticationMiddleware : AuthenticationMiddleware<DummyAuthenticationOptions>
    {
        public DummyAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app, DummyAuthenticationOptions options)
            : base(next, options)
        { 
            if(string.IsNullOrEmpty(Options.SignInAsAuthenticationType))
            {
                options.SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType();
            }
        }

        // Called for each request, to create a handler for each request.
        protected override AuthenticationHandler<DummyAuthenticationOptions> CreateHandler()
        {
            return new DummyAuthenticationHandler();
        }
    }
}
