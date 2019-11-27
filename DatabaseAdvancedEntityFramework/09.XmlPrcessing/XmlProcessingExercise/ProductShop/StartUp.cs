namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var userXml = File.ReadAllText(@"./../../../Datasets/users.xml");
                //var usersResult = ImportUsers(context, userXml);

                //var productXml = File.ReadAllText(@"./../../../Datasets/products.xml");
                //var productResult = ImportProducts(context, productXml);

                //var categoriesXml = File.ReadAllText(@"./../../../Datasets/categories.xml");
                //var categoriesResult = ImportCategories(context, categoriesXml);

                //var categoriesProductsXml = File.ReadAllText(@"./../../../Datasets/categories-products.xml");
                //var categoriesProductsResult = ImportCategoryProducts(context, categoriesProductsXml);

                var result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            using var reader = new StringReader(inputXml);

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(reader);

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if(categoryDto.Name == null)
                {
                    continue;
                }

                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var product = context.Products.Find(categoryProductDto.ProductId);
                var category = context.Categories.Find(categoryProductDto.CategoryId);

                if (product == null || category == null)
                {
                    continue;
                }

                var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);

                //or
                //var cateogryProducs = new CategoryProduct
                //{
                //    ProductId = product.Id,
                //    CategoryId = category.Id
                //});

                categoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductDto = u.ProductsSold
                        .Select(p => new ProductDto
                         {
                             Name = p.Name,
                             Price = p.Price
                         })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryWithProductDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryWithProductDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserAndProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        ProductDto = u.ProductsSold.
                            Select(p => new ProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(p => p.SoldProductDto.Count)
                .Take(10)
                .ToArray();

            var customExport = new CustomUserProductDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                UserAndProductDto = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomUserProductDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}