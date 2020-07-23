using Cars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Repository
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override void Remove(long id)
        {
            var manufacturerToRemove = context.Manufacturers.Find(id);

            var relatedCar = context.Cars
                .Include(x=>x.Manufacturer)
                .FirstOrDefault(x => x.Manufacturer.Id == id);

            if (relatedCar != null)
            {
                relatedCar.Manufacturer = null;
            }

            context.Manufacturers.Remove(manufacturerToRemove);

            context.SaveChanges();
        }
    }
}
