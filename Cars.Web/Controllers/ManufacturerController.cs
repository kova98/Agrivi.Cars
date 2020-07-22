using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.DTO;
using Cars.DTO.Manufacturer;
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

        public IActionResult ManufacturersList(int page = 1)
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
            return View();
        }

    }
}
