using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using SULSApp.Controllers;

namespace SULSApp
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset-css.css", new StaticFilesController().Reset));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/bootstrap.min.css", new StaticFilesController().Bootstrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));

            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController().Login));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController().Register));
            routeTable.Add(new Route(HttpMethodType.Get, "/Submissions/Create", new SubmissionsController().Create));
            routeTable.Add(new Route(HttpMethodType.Get, "/Problems/Create", new ProblemsController().Create));
            routeTable.Add(new Route(HttpMethodType.Get, "/Problems/Details", new ProblemsController().Details));
        }

        public void ConfigureServices()
        {
            using (var db = new SulsDbContex())
            {
                db.Database.Migrate();
            }
        }
    }
}
