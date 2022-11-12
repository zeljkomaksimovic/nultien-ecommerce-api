using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Enums;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer Mappings
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            #endregion Customer

            #region Product Mappings
            CreateMap<Product, ProductDto>()
                .ReverseMap();
            CreateMap<Product, CreateProductDto>()
                .ReverseMap();
            #endregion Customer

            #region ShoppingCart Mappings
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            #endregion ShoppingCart

            #region Order Mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            #endregion Customer
        }
    }
}
