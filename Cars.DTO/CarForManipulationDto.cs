using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.DTO
{
    public abstract class CarForManipulationDto
    {
        public string Model { get; set; }
        public DateTimeOffset ManufacturingDate { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
    }
}
