
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XsCoinWeb.APPCode;
using System.Web;
using System.Web.Http.Results;
using System.Security.Policy;

namespace XsCoinWeb.filter
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";
        private readonly bool _isActive = true;

        public AuthorizationRequiredAttribute()
        {
        }
        public AuthorizationRequiredAttribute(bool isActive)
        {
            _isActive = isActive;
        }

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (!_isActive) return;
            Uri MyUrl = filterContext.Request.RequestUri;

            string value = filterContext.Request.Headers.Authorization.ToString();
            if (value != null)
            {

                byte[] encodedDataAsBytes = System.Convert.FromBase64String(value);
                string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
                ClassUserAccount provider = new ClassUserAccount();
                if (provider != null && !provider.ValidateToken(returnValue))
                {
                    
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                         
                    ReasonPhrase = "Invalid Request"
                    };
                    filterContext.Response = responseMessage;
                }


            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);

        }
    }
}