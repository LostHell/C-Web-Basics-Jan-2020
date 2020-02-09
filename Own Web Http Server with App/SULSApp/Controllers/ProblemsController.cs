using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SULSApp.Controllers
{
    public class ProblemsController : Controller
    {
        public HttpResponse Create(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Details(HttpRequest request)
        {
            return this.View();
        }
    }
}
