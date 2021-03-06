﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.DTO;
using Cars.DTO.Manufacturer;
using Cars.Models;
using Cars.Repository;
using Cars.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IManufacturerRepository manufacturerRepo;

        private const int PageSize = 5;

        public ManufacturerController(IManufacturerRepository manufacturerRepo, IMapper mapper)
        {
            this.manufacturerRepo = manufacturerRepo;
            this.mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            page = page < 1 ? 1 : page;

            var manufacturers = manufacturerRepo.GetAll(page: page, pageSize: PageSize);
            var manufacturersDto = mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);

            var viewModel = new ManufacturersListViewModel
            {
                Manufacturers = manufacturersDto,
                PageSize = PageSize,
                Page = page
            };

            return View(viewModel);
        }

        public IActionResult AddManufacturer()
        {
            return View(new ManufacturerForCreationDto());
        }

        public IActionResult SaveManufacturer(ManufacturerForCreationDto manufacturerDto)
        {
            var manufacturer = mapper.Map<Manufacturer>(manufacturerDto);

            manufacturerRepo.Add(manufacturer);

            return RedirectToAction("Index");
        }

        public IActionResult EditManufacturer(long id)
        {
            var manufacturer = manufacturerRepo.Get(id);
            var manufacturerDto = mapper.Map<ManufacturerForUpdateDto>(manufacturer);

            var viewModel = new EditManufacturerViewModel
            {
                ManufacturerDto = manufacturerDto,
                ManufacturerId = id
            };

            return View(viewModel);
        }

        public IActionResult UpdateManufacturer(EditManufacturerViewModel viewModel)
        {
            var manufacturer = mapper.Map<Manufacturer>(viewModel.ManufacturerDto);
            manufacturer.Id = viewModel.ManufacturerId;

            manufacturerRepo.Update(manufacturer);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveManufacturer(long id)
        {
            manufacturerRepo.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
