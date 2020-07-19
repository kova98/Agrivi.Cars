using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.DTO;
using Cars.Repository;
using Cars.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICarRepository carRepo;

        private int pageSize = 5;

        public CarController(IMapper mapper, ICarRepository carRepo)
        {
            this.mapper = mapper;
            this.carRepo = carRepo;
        }

        public IActionResult Index(string manufacturerName = "", int page = 1)
        {
            page = page < 1 ? 1 : page;
            manufacturerName ??= "";

            var carsFromRepo = carRepo.GetAll(
                x => x.Manufacturer.Name.ToUpperInvariant().Contains(manufacturerName.ToUpperInvariant()), 
                page, 
                pageSize);

            var cars = mapper.Map<IEnumerable<CarDto>>(carsFromRepo);

            return View(new CarsListViewModel { Cars = cars, Page = page, PageSize = pageSize });
        }
    }
}
