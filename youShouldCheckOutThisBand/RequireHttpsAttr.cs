//see here: https://www.youtube.com/watch?v=xIzlD-frEw4
namespace youShouldCheckOutThisBand
{


    //notes:
    /*commented out until I figure out how ot make it up to date in .net core
     * to use this class, add it to the HttpConfiguration as a filter
     * ex. config.Filters.Add(new RequireHttpsAttribute());
     * if you only want it for some come controllers, use it as a decorator
     * ex. [RequireHttps]
     */

    //public class RequireHttpsAttr :AuthorizationFilterAttribute
    //{
    //    //override = changes method from a baseclass
    //    public override void OnAuthorization(HttpActionContext actionContext)
    //    {
    //        if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
    //        {
    //            //we have found the uri you are looking fro but you have to use https instead of http
    //            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
    //            actionContext.Response.Content = new StringContent("<p>Use HTTPS instead of HTTP</p>", Encoding.UTF8, "text/html");

    //            UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
    //            uriBuilder.Scheme = Uri.UriSchemeHttps;
    //            uriBuilder.Port = 44306;//the http port number for your project

    //            actionContext.Response.Headers.Location = uriBuilder.Uri;
    //        }
    //        else {
    //            //execute base class
    //        }
    //        base.OnAuthorization(actionContext);
    //    }

    //}
}
