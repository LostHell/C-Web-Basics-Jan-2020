using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SULSApp.Controllers
{
    public class SubmissionsController : Controller
    {
        public HttpResponse Create(HttpRequest request)
        {
            return this.View();
        }
    }
}
