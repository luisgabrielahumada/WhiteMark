using SiteMark.Helper;
using SiteMark.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SiteMark.Controllers
{
    public class WebController : ApiController
    {
        [HttpGet()]
        public HttpResponseMessage Mark(string token)
        {
            var configurationWeb = new ConfigurationWeb
            {
                Url = ConfigurationManager.AppSettings[$"Url_{token}"].ToString(),
                JqueryVersion = ConfigurationManager.AppSettings[$"JqueryVersion_{token}"].ToString(),
                Layaout = ConfigurationManager.AppSettings[$"Layaout_{token}"].ToString(),
                Css = ConfigurationManager.AppSettings[$"Css_{token}"].ToString(),
                Code = ConfigurationManager.AppSettings[$"Code_{token}"].ToString(),
                UserID = ConfigurationManager.AppSettings[$"UserID_{token}"].ToString(),
                OldRepleace = ConfigurationManager.AppSettings[$"OldRepleace_{token}"].ToString(),
                NewRepleace = ConfigurationManager.AppSettings[$"NewRepleace_{token}"].ToString(),
            };

            var data = HttpWebHtml.GetResponseString(configurationWeb.FullUrl);
            if (!string.IsNullOrEmpty(configurationWeb.OldRepleace) && !string.IsNullOrEmpty(configurationWeb.NewRepleace))
                data = data.Replace(configurationWeb.OldRepleace, configurationWeb.NewRepleace);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(data);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
