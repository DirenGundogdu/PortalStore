using AutoMapper;
using Core.Entities;
using DTO;

namespace Business.Mapping;

public class MapProfile : Profile
{
    public MapProfile() {
        
        CreateMap<Address,AddressDto>().ReverseMap();
        CreateMap<Address,AddressProcessDto>().ReverseMap();

        CreateMap<Category,CategoryDto>().ReverseMap();

        CreateMap<Customer,CustomerDto>().ReverseMap();

        CreateMap<OrderItem,OrderItemDto>().ReverseMap();

        CreateMap<Order,OrderDto>().ReverseMap();

        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<Product, ProductProcessDto>().ReverseMap();

        CreateMap<Basket, BasketDto>().ReverseMap();
        CreateMap<Basket, BasketProcessDto>().ReverseMap();



    }
}
