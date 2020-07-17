using AutoMapper;
using CarPark.API.DTOs;
using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Mapping {
    public class MapProfile : Profile{

        public MapProfile() {
            CreateMap<Park, ParkDto>();
            CreateMap<ParkDto, Park>();
            CreateMap<Car, CarDto>();
            CreateMap<Park, ParkWithCarDto>();
            CreateMap<ParkWithCarDto, Park>();
            CreateMap<CarDto, Car>();
            CreateMap<Car, CarWithParkDto>();
            CreateMap<CarWithParkDto, Car>();
           

        }
    }
}
