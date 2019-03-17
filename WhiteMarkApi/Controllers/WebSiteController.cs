using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhiteMarkApi.Helper;

namespace WhiteMarkApi.Controllers
{
    public class WebSiteController : ApiController
    {
        [HttpGet()]
        [SwaggerOperation("MarkWebSite")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public HttpResponseMessage Mark(string token)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new{ data  = HttpWebHtml.GetResponseString("http://www.google.com") });
        }
    }
}
