using Cars.DTO.Manufacturer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.DTO.Car
{
    public abstract class CarForManipulationDto
    {
        public string Model { get; set; }
        public DateTimeOffset ManufacturingDate { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
    }
}
