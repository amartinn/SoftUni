using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ExportProductsInRageDTO>()
                .ForMember(m => m.Buyer, opt => opt.MapFrom(x => $"{x.Buyer.FirstName} {x.Buyer.LastName}"));
            this.CreateMap<Product, ExportSoldProductDTO>();

            this.CreateMap<User, ExportUserWithSoldProductDTO>()
                .ForMember(m => m.SoldProducts, opt => opt.MapFrom(x => x.ProductsSold));
            this.CreateMap<Category, ExportCategoryByProductCountDTO>()
                .ForMember(m => m.Count, opt => opt.MapFrom(c => c.CategoryProducts.Count))
                .ForMember(m => m.AveragePrice, opt => opt.MapFrom(c => c.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(m => m.TotalRevenue, opt => opt.MapFrom(c => c.CategoryProducts.Sum(p => p.Product.Price)));

        }  
    }
}
