using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.DTO;
using Cars.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICarRepository carRepo;

        public CarController(IMapper mapper, ICarRepository carRepo)
        {
            this.mapper = mapper;
            this.carRepo = carRepo;
        }

        public IActionResult Index()
        {
            var carsFromRepo = carRepo.GetAll();
            var cars = mapper.Map<IEnumerable<CarDto>>(carsFromRepo);

            return View(cars);
        }
    }
}
