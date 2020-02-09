using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MvcFramework;

namespace SULSApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }
    }
}
