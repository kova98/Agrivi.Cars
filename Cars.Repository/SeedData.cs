using Cars.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Repository
{
    public static class SeedData
    {
        private static readonly Random random = new Random();

        public static Car[] GetDummyCars()
        {
            var cars = new Car[]
            {
                new Car { ManufacturingDate = GetRandomYear(), Model = "Aygo",           Manufacturer = new Manufacturer { Name = "Toyota"} },
                new Car { ManufacturingDate = GetRandomYear(), Model = "Civic 5V",       Manufacturer = new Manufacturer { Name = "Honda"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Spark",          Manufacturer = new Manufacturer { Name = "Chevrolet"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Focus",          Manufacturer = new Manufacturer { Name = "Ford"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "A-Class",        Manufacturer = new Manufacturer { Name = "Mercedes-Benz"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Renegade",       Manufacturer = new Manufacturer { Name = "Jeep"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "2 Series Coupe", Manufacturer = new Manufacturer { Name = "BMW"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "718 Cayman",     Manufacturer = new Manufacturer { Name = "Porshe"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Forester",       Manufacturer = new Manufacturer { Name = "Subaru"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Qashqai",        Manufacturer = new Manufacturer { Name = "Nissan"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "XT4",            Manufacturer = new Manufacturer { Name = "Cadillac"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Polo",           Manufacturer = new Manufacturer { Name = "Volkswagen"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "RX",             Manufacturer = new Manufacturer { Name = "Lexus"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "Q5",             Manufacturer = new Manufacturer { Name = "Audi"}},
                new Car { ManufacturingDate = GetRandomYear(), Model = "SF90 Stradale",  Manufacturer = new Manufacturer { Name = "Ferrari"}},
            };

            return cars;
        }

        private static DateTime GetRandomYear()
        {
            return DateTime.Now.AddYears(random.Next(-20, 0));
        }
    }
}
