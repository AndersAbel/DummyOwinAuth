using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyOwinAuth
{
    public class DummyAuthenticationOptions : AuthenticationOptions
    {
        public DummyAuthenticationOptions(string userName)
            : base(Constants.DefaultAuthenticationType)
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-dummy");
            AuthenticationMode = AuthenticationMode.Passive;
            UserName = userName;
        }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        public PathString CallbackPath { get; set; }

        public string UserName { get; set; }
    }
}
