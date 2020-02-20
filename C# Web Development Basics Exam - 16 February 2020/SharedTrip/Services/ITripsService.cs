using SharedTrip.Models;
using SharedTrip.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Add(TripsInputModel inputModel);

        IEnumerable<Trip> All();

        Trip GetById();

        void AddUserToTrip();
    }
}
