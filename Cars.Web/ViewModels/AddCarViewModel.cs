using Cars.DTO;
using Cars.DTO.Car;
using Cars.DTO.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Web.ViewModels
{
    public class AddCarViewModel
    {
        public CarForCreationDto CarDto { get; set; }
        public IEnumerable<ManufacturerDto> Manufacturers { get; set; }
    }
}
