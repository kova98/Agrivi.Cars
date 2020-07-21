using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.DTO;
using Cars.Models;
using Cars.Repository;
using Cars.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICarRepository carRepo;

        private const int PageSize = 5;

        public CarController(IMapper mapper, ICarRepository carRepo)
        {
            this.mapper = mapper;
            this.carRepo = carRepo;
        }

        public IActionResult Index(string orderBy = "", string manufacturerName = "", int page = 1)
        {
            page = page < 1 ? 1 : page;
            manufacturerName ??= "";

            var carsFromRepo = carRepo.GetAll(
                x => x.Manufacturer.Name.ToUpperInvariant().Contains(manufacturerName.ToUpperInvariant()),
                GetOrderByDelegate(orderBy),
                page,
                PageSize);

            var cars = mapper.Map<IEnumerable<CarDto>>(carsFromRepo);

            var viewModel = new CarsListViewModel 
            { 
                Cars = cars, 
                Page = page, 
                PageSize = PageSize, 
                ManufacturerName = manufacturerName,
                OrderBy = orderBy
            };

            return View(viewModel);
        }

        private Func<IQueryable<Car>, IOrderedQueryable<Car>> GetOrderByDelegate(string orderBy)
        {
            return orderBy switch
            {
                "model"         => x => x.OrderBy(x => x.Model),
                "year"          => x => x.OrderBy(x => x.ManufacturingDate),
                "manufacturer"  => x => x.OrderBy(x => x.Manufacturer.Name),
                _               => x => x.OrderBy(x => x.Id)
            };
        }


    }
}
