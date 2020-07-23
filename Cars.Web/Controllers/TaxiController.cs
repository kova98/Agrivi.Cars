using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Models;
using Cars.Scheduler;
using Cars.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.Controllers
{
    public class TaxiController : Controller
    {
        public IActionResult Index()
        {
            return View(new Taxi[3]);
        }

        public IActionResult EnterTaxis(ICollection<Taxi> taxis)
        { 
            var optimizer = new TripOptimizer(taxis);

            var viewModel = new TripsListViewModel
            {
                AllTrips = optimizer.GetAllTrips(),
                BestTrips = optimizer.GetBestTrips()
            };

            return View("TripsList", viewModel);
        }
    }
}
