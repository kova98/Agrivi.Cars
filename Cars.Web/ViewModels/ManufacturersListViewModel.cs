using Cars.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Web.ViewModels
{
    public class ManufacturersListViewModel
    {
        public IEnumerable<ManufacturerDto> Manufacturers { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
