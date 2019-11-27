using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new ProductShopContext())
            {
                Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Problem 01
                //var inputJson = File.ReadAllText("./../../../Datasets/users.json");

                //Problem 02
                //var inputJson = File.ReadAllText("./../../../Datasets/products.json");

                //Problem 03
                //var inputJson = File.ReadAllText("./../../../Datasets/categories.json");

                //Problem 04
                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                var result = GetUsersWithProducts(context);

                Console.WriteLine(result);
            }
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.price)
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(sp => sp.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            var json = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented, json);

            return categoriesJson;
        }

        //Problem 08
        public static string GetUsersWithProducts1(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var userOutput = new
            {
                usersCount = users.Count,
                users
            };

            var json = JsonConvert.SerializeObject(userOutput, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        //Problem 08 - Second way with DTO
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .ProjectTo<UserDetailsDto>()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            //var userOutput = new UserInfoDto()
            //{
            //    UsersCount = users.Length,
            //    Users = users
            //};
            var userOutput = Mapper.Map<UserInfoDto>(users);

            var defaultResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(userOutput, new JsonSerializerSettings
            {
                ContractResolver = defaultResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;

        }
    }
}