using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyOwinAuth
{
    public static class DummyAuthenticationExtensions
    {
        public static IAppBuilder UseDummyAuthentication(this IAppBuilder app, DummyAuthenticationOptions options)
        {
            return app.Use(typeof(DummyAuthenticationMiddleware), app, options);
        }
    }
}
