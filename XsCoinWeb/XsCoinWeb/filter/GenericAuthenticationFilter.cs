using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace XsCoinWeb.filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class GenericAuthenticationFilter : AuthorizationFilterAttribute
    {
        public GenericAuthenticationFilter()
        {
        }
        private readonly bool _isActive = true;
        public GenericAuthenticationFilter(bool isActive)
        {
            _isActive = isActive;
        }
        // Checks basic authentication request
        public override void OnAuthorization(HttpActionContext filterContext)
        {
             return;
            var identity = FetchAuthHeader(filterContext);
            if (identity == null)
            {
                ChallengeAuthRequest(filterContext);
                return;
            }
            var genericPrincipal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = genericPrincipal;
            if (!OnAuthorizeUser(filterContext))
            {
                ChallengeAuthRequest(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
        }
        // Virtual method.Can be overriden with the custom Authorization.
        protected virtual bool OnAuthorizeUser(HttpActionContext filterContext)
        {
            
            return true;
        }
        // Checks for autrhorization header in the request and parses it, creates user credentials and returns as BasicAuthenticationIdentity
        protected virtual BasicAuthenticationIdentity FetchAuthHeader(HttpActionContext filterContext)
        {
            string authHeaderValue = null;
            var authRequest = filterContext.Request.Headers.Authorization;
            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            if (!authHeaderValue.Contains(".com"))
            {
                if (!authHeaderValue.Contains(":"))

                {
                    authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
                }
            }
            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1]);
        }
        // Send the Authentication Challenge request
        private static void ChallengeAuthRequest(HttpActionContext filterContext)
        {
            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }

    }
}