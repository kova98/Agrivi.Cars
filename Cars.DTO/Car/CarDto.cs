using Cars.DTO.Manufacturer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.DTO.Car
{
    public class CarDto
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
    }
}
