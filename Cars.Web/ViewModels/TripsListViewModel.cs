using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.ViewModels
{
    public class TripsListViewModel
    {
        public List<Trip> AllTrips { get; set; }
        public List<Trip> BestTrips { get; set; }
    }
}
