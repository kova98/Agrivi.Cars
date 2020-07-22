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
        private readonly IManufacturerRepository manufacturerRepo;

        private const int PageSize = 5;

        public CarController(IMapper mapper, ICarRepository carRepo, IManufacturerRepository manufacturerRepo)
        {
            this.mapper = mapper;
            this.carRepo = carRepo;
            this.manufacturerRepo = manufacturerRepo;
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

        public IActionResult AddCar()
        {
            var manufacturersFromRepo = manufacturerRepo.GetAll();
            var manufacturersDto = mapper.Map<IEnumerable<ManufacturerDto>>(manufacturersFromRepo);

            var viewModel = new AddCarViewModel
            {
                CarDto = new CarForCreationDto(),
                Manufacturers = manufacturersDto
            };
            
            return View(viewModel);
        }

        public IActionResult SaveCar(AddCarViewModel viewModel)
        {
            var car = mapper.Map<Car>(viewModel.CarDto);
            carRepo.Add(car);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCar(long id)
        {
            carRepo.Remove(id);

            return RedirectToAction("Index");
        }

        public IActionResult EditCar(long id)
        {
            var carToUpdate = carRepo.Get(id);
            var carToUpdateDto = mapper.Map<CarForUpdateDto>(carToUpdate);

            var manufacturersFromRepo = manufacturerRepo.GetAll();
            var manufacturersDto = mapper.Map<IEnumerable<ManufacturerDto>>(manufacturersFromRepo);

            var viewModel = new EditCarViewModel
            {
                CarId = id,
                CarDto = carToUpdateDto,
                Manufacturers = manufacturersDto
            };

            return View(viewModel);
        }

        public IActionResult UpdateCar(EditCarViewModel viewModel)
        {
            var car = mapper.Map<Car>(viewModel.CarDto);
            car.Id = viewModel.CarId;

            carRepo.Update(car);

            return RedirectToAction("Index");
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
