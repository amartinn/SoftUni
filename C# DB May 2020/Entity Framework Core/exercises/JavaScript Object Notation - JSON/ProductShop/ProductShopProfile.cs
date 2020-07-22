using AutoMapper;
using ProductShop.DTO;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductDTO>()
                .ForMember(m => m.Seller, 
                opt => opt.MapFrom(x => $"{x.Seller.FirstName} {x.Seller.LastName}"));
            this.CreateMap<Product, SoldProductDTO>();
            this.CreateMap<User, UserWithSoldProductsDTO>()
                .ForMember(m => m.SoldProducts,
                opt => opt.MapFrom(x => x.ProductsSold.Where(c => c.Buyer != null)));

            this.CreateMap<Category, CategoryDTO>()
                .ForMember(m => m.AveragePrice,
                opt => opt.MapFrom(x => decimal.Round(x.CategoryProducts.Average(p => p.Product.Price),2)))
                .ForMember(m => m.TotalRevenue,
                opt => opt.MapFrom(x => x.CategoryProducts.Sum(p => p.Product.Price)))
                .ForMember(m => m.CategoryName,
                opt => opt.MapFrom(c => c.Name))
                .ForMember(m => m.ProductsCount,
                opt => opt.MapFrom(c => c.CategoryProducts.Count()));
                
                
        }
    }
}
