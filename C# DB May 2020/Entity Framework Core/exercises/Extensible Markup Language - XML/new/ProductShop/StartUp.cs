namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using ProductShop.XMLHelper;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper.Configuration;
    using AutoMapper.QueryableExtensions;
    using System.Xml.Serialization;
    using System;
    using System.Text;
    using ProductShop.Dtos.Export;

    public class StartUp
    {
        private static readonly MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
            cfg.AddProfile<ProductShopProfile>();
        });
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                File.WriteAllText("../../../Results/products-in-range.xml", GetProductsInRange(db));
                File.WriteAllText("../../../Results/users-sold-products.xml", GetSoldProducts(db));
                File.WriteAllText("../../../Results/categories-by-products.xml", GetCategoriesByProductsCount(db));
                

            }

        }
        public static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        public static void SeedDatabase(ProductShopContext context)
        {
            var sb = new StringBuilder();
           sb.AppendLine(ImportUsers(context, File.ReadAllText("./Datasets/users.xml")));
           sb.AppendLine(ImportProducts(context, File.ReadAllText("./Datasets/products.xml")));
           sb.AppendLine(ImportCategories(context, File.ReadAllText("./Datasets/categories.xml")));
            sb.AppendLine(ImportCategoryProducts(context, File.ReadAllText("./Datasets/categories-products.xml")));

            Console.WriteLine(sb.ToString());
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";
            var users = XmlConverter.Deserializer<ImportUserDTO>(inputXml, root)
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                }).ToList();
            ;
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";
            var products = XmlConverter.Deserializer<ImportProductDTO>(inputXml, root)
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerId = p.BuyerId,
                    SellerId = p.SellerId
                })
                .ToList();
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";
            var categories = XmlConverter.Deserializer<ImportCategoryDTO>(inputXml, root)
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";
            var categoriesId = context.Categories.Select(c => c.Id).ToList();
            var productsId = context.Products.Select(c => c.Id).ToList();
            var categoryProducts = XmlConverter.Deserializer<ImportCategoryProductDTO>(inputXml, root)
                .Where(c => categoriesId.Any(id => id == c.CategoryId) && productsId.Any(id => id == c.ProductId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId,
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";


        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";
            var products = context.Products.Where(p => p.Price > 500 && p.Price < 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsInRageDTO>(mapperConfig)
                .Take(10)
                .ToList();

            var xml = XmlConverter.Serialize(products, root);
            
            return xml;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";
            var usersWithSoldProducts = context.Users.Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserWithSoldProductDTO>(mapperConfig)
                .Take(5)
                .ToList();
            var xml = XmlConverter.Serialize(usersWithSoldProducts, root);

            return xml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";
            var categories = context.Categories
                .ProjectTo<ExportCategoryByProductCountDTO>(mapperConfig)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xml = XmlConverter.Serialize(categories, root);

            return xml;
        }
        
    }
}