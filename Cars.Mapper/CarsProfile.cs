using AutoMapper;
using Cars.DTO;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Mapper
{
    class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarDto>();
        }
    }
}
