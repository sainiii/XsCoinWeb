
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace XsCoinWeb.filter
{

    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public ApiAuthenticationFilter()
        {
        }
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }
        // Protected overriden method for authorizing user
        protected override bool OnAuthorizeUser(HttpActionContext actionContext)
        {

            //  Get API key provider

            string value = actionContext.Request.Headers.Authorization.ToString();
            if (value != null)
            {
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(value);
                //  string returnValue = TokenEncode.Decode(value);
                // Validate Token
                //if (provider != null && !provider.ValidateToken(returnValue))
                //{
                //    

                //}

                return true;
            }
            return false;

        }
    }
}