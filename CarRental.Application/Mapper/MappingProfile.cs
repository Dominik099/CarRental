using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.UsersAccounts.Commands;
using CarRental.Application.Functions.UsersAccounts.Query.UserLogin;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;

namespace CarRental.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<Car, PriceCategoryDto>();
            CreateMap<PriceCategory, PriceCategoryDto>();
            CreateMap<PriceCategoryDto, CarDto>();
            CreateMap<CarAddress, CarAddressDto>().ReverseMap();
            CreateMap<CarAddress, UpdateCarAddressCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
        }
    }
}
