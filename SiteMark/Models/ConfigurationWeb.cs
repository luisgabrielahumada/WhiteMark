using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMark.Models
{
    public class ConfigurationWeb
    {
        public string Url { get; set; }
        public string Layaout { get; set; }
        public string JqueryVersion { get; set; }
        public string Code { get; set; }
        public string UserID { get; set; }
        public string Css { get; set; }
        public string NewRepleace { get; set; }
        public string OldRepleace { get; set; }

        public string FullUrl {
            get
            {
                return $"{Url}?layaout={Layaout}&jquery={JqueryVersion}&code={Code}&UserID={UserID}&css={Css}";
            }
        }
    }
}