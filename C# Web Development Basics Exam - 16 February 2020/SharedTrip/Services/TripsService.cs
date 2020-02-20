using SharedTrip.Models;
using SharedTrip.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(TripsInputModel inputModel)
        {
            var trip = new Trip()
            {
                StartPoint = inputModel.StartPoint,
                EndPoint = inputModel.EndPoint,
                DepartureTime = inputModel.DepartureTime,
                Seats = inputModel.Seats,
                Description = inputModel.Description,
                ImagePath = inputModel.ImagePath,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public void AddUserToTrip()
        {
            var user = this.db.Users.FirstOrDefault();
            var trip = this.db.Trips.FirstOrDefault();

            //if (user.UserTrips.FirstOrDefault(x => x.Trip == trip))
            //{
            //    ;
            //}

            var userTrip = new UserTrip()
            {
                User = user,
                Trip = trip
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<Trip> All()
        {
            var allTrips = this.db.Trips.ToArray();
            return allTrips;
        }

        public Trip GetById()
            => this.db.Trips.FirstOrDefault();
    }
}
