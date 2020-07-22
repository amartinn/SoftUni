using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static readonly MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
            cfg.AddProfile<ProductShopProfile>();
        });
        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
            , NullValueHandling = NullValueHandling.Ignore
        };
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                ResetDatabase(db);
                SeedDatabase(db);
            };
        }


        public static void SeedDatabase(ProductShopContext context)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ImportUsers(context, File.ReadAllText("../../../Datasets/users.json")));
            sb.AppendLine(ImportProducts(context, File.ReadAllText("../../../Datasets/products.json")));
            sb.AppendLine(ImportCategories(context, File.ReadAllText("../../../Datasets/categories.json")));
            sb.AppendLine(ImportCategoryProducts(context, File.ReadAllText("../../../Datasets/categories-products.json")));

            Console.WriteLine(sb.ToString());
        }
        public static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductDTO>(mapperConfig)
                .ToList();
            return JsonConvert.SerializeObject(products, jsonSettings);
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                 .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserWithSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(sp => sp.Buyer != null)
                    .Select(sp => new SoldProductDTO {
                        Name = sp.Name,
                        Price = sp.Price,
                        BuyerFirstName = sp.Buyer.FirstName,
                        BuyerLastName = sp.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(users, jsonSettings);

        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories =
                context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .ProjectTo<CategoryDTO>(mapperConfig)
                .ToList();

            return JsonConvert.SerializeObject(categories, jsonSettings);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users =
                context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold.Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        }).ToList()
                    }
                })
                .OrderBy(u => u.soldProducts.count)
                .ToList();
            var resultObject = new {
                usersCount = users.Count,
                users
            };
            return JsonConvert.SerializeObject(resultObject, jsonSettings);
        }
    }
    
}