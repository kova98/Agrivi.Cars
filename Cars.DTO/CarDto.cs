using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.DTO
{
    class CarDto
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public long ManufacturerId { get; set; }
    }
}
