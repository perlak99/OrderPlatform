using OrderApi.DTOs;
using OrderApi.Models.Entities;
using AutoMapper;

namespace OrderApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Orders
            CreateMap<AddOrderDto, Order>();
        }
    }
}
