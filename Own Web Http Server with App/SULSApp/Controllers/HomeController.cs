using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MvcFramework;

namespace SULSApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
