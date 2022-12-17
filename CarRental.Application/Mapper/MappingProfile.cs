using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;

namespace CarRental.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<PriceCategory, PriceCategoryDto>().ReverseMap();
            CreateMap<PriceCategoryDto, CarViewModel>().ForMember(x => x.PriceCategory, x => x.MapFrom(x => x.Category));
            CreateMap<CarAddress, CarAddressViewModel>().ReverseMap();

        }
    }
}
