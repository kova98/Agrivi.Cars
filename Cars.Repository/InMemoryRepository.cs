using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Repository
{
    public class InMemoryRepository : ICarRepository
    {
        private List<Car> cars = new List<Car>();
        Random random = new Random();

        public InMemoryRepository()
        {
            PopulateCarsList();
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Remove(long id)
        {
            var carToRemove = cars.Find(x => x.Id == id);
            cars.Remove(carToRemove);
        }

        public Car Get(long id)
        {
            var car = cars.Find(x => x.Id == id);

            return car;
        }

        public IEnumerable<Car> GetAll(int page = 1, int pageSize = 10)
        {
            return cars
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public void Update(Car car)
        {
            var carToUpdate = cars.Find(x=>x.Id == car.Id);

            carToUpdate = car;
        }

        private void PopulateCarsList()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Id = 0, Name = "Toyota"},
                new Manufacturer { Id = 1, Name = "Honda"},
                new Manufacturer { Id = 2, Name = "Chevrolet"},
                new Manufacturer { Id = 3, Name = "Ford"},
                new Manufacturer { Id = 4, Name = "Mercedes-Benz"},
                new Manufacturer { Id = 5, Name = "Jeep"},
                new Manufacturer { Id = 6, Name = "BMW"},
                new Manufacturer { Id = 7, Name = "Porshe"},
                new Manufacturer { Id = 8, Name = "Subaru"},
                new Manufacturer { Id = 9, Name = "Nissan"},
                new Manufacturer { Id = 10, Name = "Cadillac"},
                new Manufacturer { Id = 11, Name = "Volkswagen"},
                new Manufacturer { Id = 12, Name = "Lexus"},
                new Manufacturer { Id = 13, Name = "Audi"},
                new Manufacturer { Id = 14, Name = "Ferrari"},
            };

            cars.AddRange(new Car[]
            {
                new Car {Id = 0, ManufacturingDate = GetRandomYear(), Model = "Aygo", Manufacturer = manufacturers.Find(x=>x.Id == 0)},
                new Car {Id = 1, ManufacturingDate = GetRandomYear(), Model = "Civic 5V", Manufacturer = manufacturers.Find(x=>x.Id == 1)},
                new Car {Id = 2, ManufacturingDate = GetRandomYear(), Model = "Spark", Manufacturer = manufacturers.Find(x=>x.Id == 2)},
                new Car {Id = 3, ManufacturingDate = GetRandomYear(), Model = "Focus", Manufacturer = manufacturers.Find(x=>x.Id == 3)},
                new Car {Id = 4, ManufacturingDate = GetRandomYear(), Model = "A-Class", Manufacturer = manufacturers.Find(x=>x.Id == 4)},
                new Car {Id = 5, ManufacturingDate = GetRandomYear(), Model = "Renegade", Manufacturer = manufacturers.Find(x=>x.Id == 5)},
                new Car {Id = 6, ManufacturingDate = GetRandomYear(), Model = "2 Series Coupe", Manufacturer = manufacturers.Find(x=>x.Id == 6)},
                new Car {Id = 7, ManufacturingDate = GetRandomYear(), Model = "718 Cayman", Manufacturer = manufacturers.Find(x=>x.Id == 7)},
                new Car {Id = 8, ManufacturingDate = GetRandomYear(), Model = "Forester", Manufacturer = manufacturers.Find(x=>x.Id == 8)},
                new Car {Id = 9, ManufacturingDate = GetRandomYear(), Model = "Qashqai", Manufacturer = manufacturers.Find(x=>x.Id == 9)},
                new Car {Id = 10, ManufacturingDate = GetRandomYear(), Model = "XT4", Manufacturer = manufacturers.Find(x=>x.Id == 10)},
                new Car {Id = 11, ManufacturingDate = GetRandomYear(), Model = "Polo", Manufacturer = manufacturers.Find(x=>x.Id == 11)},
                new Car {Id = 12, ManufacturingDate = GetRandomYear(), Model = "RX", Manufacturer = manufacturers.Find(x=>x.Id == 12)},
                new Car {Id = 13, ManufacturingDate = GetRandomYear(), Model = "Q5", Manufacturer = manufacturers.Find(x=>x.Id == 13)},
                new Car {Id = 14, ManufacturingDate = GetRandomYear(), Model = "SF90 Stradale", Manufacturer = manufacturers.Find(x=>x.Id == 14)},
            });
        }

        DateTime GetRandomYear()
        {
            return DateTime.Now.AddYears(random.Next(-20, 0));
        }
    }
}
