using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Business.Mapping;

public class MapProfile : Profile
{
    public MapProfile() {
        
        CreateMap<Address,AddressDto>().ReverseMap();

        CreateMap<Category,CategoryDto>().ReverseMap();

        CreateMap<Customer,CustomerDto>().ReverseMap();

        CreateMap<OrderItem,OrderItemDto>().ReverseMap();

        CreateMap<Order,OrderDto>().ReverseMap();

        CreateMap<Product,ProductDto>().ReverseMap();

    }
}
