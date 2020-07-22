using AutoMapper;
using Cars.DTO;
using Cars.DTO.Manufacturer;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Mapper
{
    public class ManufacturersProfile : Profile
    {
        public ManufacturersProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<ManufacturerDto, Manufacturer>();
            CreateMap<ManufacturerForCreationDto, Manufacturer>();
        }
    }
}
