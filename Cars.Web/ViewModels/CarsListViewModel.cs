using Cars.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Web.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<CarDto> Cars { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string ManufacturerName { get; set; }
        public string OrderBy { get; set; }
    }
}
