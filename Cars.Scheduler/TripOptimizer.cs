using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Scheduler
{
    public class TripOptimizer
    {
        private ICollection<Customer> customers;
        private ICollection<Taxi> taxis;
        private List<Trip> trips = new List<Trip>();

        private Random random = new Random();

        public TripOptimizer(ICollection<Taxi> taxis)
        {
            InitializeCustomers();

            this.taxis = taxis;

            GenerateTrips();
        }

        public List<Trip> GetAllTrips()
        {
            return trips.ToList();
        }

        public List<Trip> GetBestTrips()
        {
            var bestTrips = new List<Trip>();

            var tripsByCheapest = trips.OrderBy(x => x.Price).ToList();

            foreach (var trip in tripsByCheapest)
            {
                if (IsTaxiFromTripAlreadyAssigned(bestTrips, trip) == false)
                {
                    bestTrips.Add(trip);
                }
            }

            return bestTrips;
        }

        private static bool IsTaxiFromTripAlreadyAssigned(List<Trip> bestTrips, Trip trip)
        {
            return bestTrips
                .Select(x => x.Taxi)
                .Contains(trip.Taxi);
        }

        private void GenerateTrips()
        {
            foreach (var customer in customers)
            {
                foreach (var taxi in taxis)
                {
                    trips.Add(new Trip
                    {
                        Customer = customer,
                        Taxi = taxi,
                        Price = GetRandomPrice()
                    });
                }
            }
        }

        private void InitializeCustomers()
        {
            customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
                new Customer { Name = "Customer 3" },
            };
        }

        private int GetRandomPrice()
        {
            return random.Next(50, 500);
        }

    }
}
