using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SIS.HTTP;
using SIS.HTTP.Response;

namespace SULSApp.Controllers
{
   public class StaticFilesController
    {
        public HttpResponse Bootstrap(HttpRequest request)
        {
            return  new FileResponse(File.ReadAllBytes("wwwroot/css/bootstrap.min.css"),"text/css");
        }
        public HttpResponse Reset(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/reset-css.css"), "text/css");
        }
        public HttpResponse Site(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/site.css"), "text/css");
        }
    }
}
