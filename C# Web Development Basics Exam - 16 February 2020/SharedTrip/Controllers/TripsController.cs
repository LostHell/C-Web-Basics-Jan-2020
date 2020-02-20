using SharedTrip.Services;
using SharedTrip.ViewModel;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn())
            {
                var allTrips = this.tripsService.All();
                return this.View(allTrips);
            }

            return this.View();
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripsInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(inputModel.Description) || inputModel.Description.Length > 80)
            {
                return this.View();
            }

            this.tripsService.Add(inputModel);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.tripsService.GetById();

            return this.View(product);
        }

        public HttpResponse AddUserToTrip()
        {
            this.tripsService.AddUserToTrip();

            return this.Redirect("/Trips/All");
        }
    }
}
