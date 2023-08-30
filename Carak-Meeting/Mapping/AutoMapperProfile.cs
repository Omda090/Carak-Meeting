using AutoMapper;
using Carak_Meeting.DTOs;
using Carak_Meeting.Models;

namespace Carak_Meeting.Mapping
{
    public class AutoMapperProfile : Profile
    {
            public AutoMapperProfile() {



            CreateMap<UserCarak, CarakDto>();
            CreateMap<CarakDto, UserCarak>();


            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();


        }
    }
}
