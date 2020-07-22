using AutoMapper;
using Cars.DTO;
using Cars.DTO.Car;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Mapper
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarDto>() 
                .ForMember(
                    dest => dest.Year,
                    opt => opt.MapFrom(src => src.ManufacturingDate.Year));

            CreateMap<CarForCreationDto, Car>();

            CreateMap<CarForUpdateDto, Car>();
            CreateMap<Car, CarForUpdateDto>();
        }
    }
}
