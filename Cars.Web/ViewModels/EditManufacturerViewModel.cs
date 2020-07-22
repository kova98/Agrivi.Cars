using Cars.DTO.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Web.ViewModels
{
    public class EditManufacturerViewModel
    {
        public long ManufacturerId { get; set; }
        public ManufacturerForUpdateDto ManufacturerDto { get; set; }
    }
}
