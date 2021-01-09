using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace XsCoinWeb.filter
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        
        // Basic Authentication Identity Constructor
        public BasicAuthenticationIdentity(string userName, string password)
            : base(userName, "Basic")
        {
            
        }
    }

}