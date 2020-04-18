using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
//see here: https://www.youtube.com/watch?v=xIzlD-frEw4
namespace youShouldCheckOutThisBand
{
    public class RequireHttpsAttr :AuthorizationFilterAttribute
    {
        //override = changes method from a baseclass
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                //we have found the uri you are looking fro but you have to use https instead of http
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p>Use HTTPS instead of HTTP");

                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44306;//the http port number for your project

                actionContext.Response.Headers.Location = uriBuilder.Uri;
            }
            else {
                //execute base class
            }
            base.OnAuthorization(actionContext);
        }

    }
}
