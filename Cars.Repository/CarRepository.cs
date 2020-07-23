using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cars.Repository
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override void Update(Car entityToUpdate)
        {
            var existing = context.Cars.Find(entityToUpdate.Id);

            existing.Manufacturer = context.Manufacturers.Find(entityToUpdate.Manufacturer.Id);
            existing.Model = entityToUpdate.Model;
            existing.ManufacturingDate = entityToUpdate.ManufacturingDate;

            context.SaveChanges();
        }
    }
}
