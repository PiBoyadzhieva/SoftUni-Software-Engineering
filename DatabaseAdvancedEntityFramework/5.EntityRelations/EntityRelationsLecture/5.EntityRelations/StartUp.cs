namespace _5.EnttyRelations
{
    using Results;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            //db.Makes.Add(new Make
            //{
            //    Name = "Mercedes"
            //});

            //db.Makes.Add(new Make
            //{
            //    Name = "BMW"
            //});

            //db.Makes.Add(new Make
            //{
            //    Name = "Audi"
            //});

            //db.Makes.Add(new Make
            //{
            //    Name = "Opel"
            //});

            //db.Makes.Add(new Make
            //{
            //    Name = "Peugeot"
            //});

            //var opelMake = db.Makes.FirstOrDefault(m => m.Name == "Opel");

            //opelMake.Models.Add(new Model
            //{
            //    Name = "Astra",
            //    Year = 2017,
            //    Modification = "OPC"
            //});

            //opelMake.Models.Add(new Model
            //{
            //    Name = "Insignia",
            //    Year = 2019,
            //    Modification = "2.2 TDI"
            //});

            //var insigniaModel = db.Models.FirstOrDefault(m => m.Name == "Insignia");

            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "Black",
            //    Price = 20000,
            //    ProductionDate = DateTime.Now.AddDays(-100),
            //    Vin = "dnmjapsoydkenapet"
            //});

            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "White",
            //    Price = 25000,
            //    ProductionDate = DateTime.Now.AddDays(-200),
            //    Vin = "mskdorgslaygjabej"
            //});

            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "Orange",
            //    Price = 18000,
            //    ProductionDate = DateTime.Now.AddDays(-300),
            //    Vin = "eopagertmnhkopiua"
            //});

            //var car = db.Cars.FirstOrDefault();

            //var customer = new Customer
            //{
            //    FirstName = "Ivan",
            //    LastName = "Peshov",
            //    Age = 29
            //};

            //customer.Purchases.Add(new CarPurchase
            //{
            //    Car = car,
            //    PurchaseDate = DateTime.Now.AddDays(-10),
            //    Price = car.Price * 0.9m
            //});

            //db.Customers.Add(customer);

            //var customer = db.Customers.FirstOrDefault();

            //customer.Address = new Address
            //{
            //    Text = "Tintiava 15",
            //    Town = "Sofia"
            //};


            //db.Purchases
            //    .Select(p => new PurchaseResultModel
            //    {
            //        Customer = new CustomerResultModel
            //        {
            //            Name = p.Customer.FirstName + " " + p.Customer.LastName,
            //            Town = p.Customer.Address.Town,
            //        },
            //        Car = new CarResultModel
            //        {
            //            Make = p.Car.Model.Make.Name,
            //            Model = p.Car.Model.Name,
            //            Vin = p.Car.Vin,
            //        },

            //        Price = p.Price,
            //        PurchaseDate = p.PurchaseDate
            //    })
            //    .ToList();

            //Validation:
            var make = db.Makes.FirstOrDefault(m => m.Name == "Mercedes");

            var model = new Model
            {
                Modification = "500",
                Name = "CL",
                Year = 3000
            };

            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            Validator.ValidateObject(model, validationContext, true);  //if it is will return error and stop

            //Validator.TryValidateObject(model, validationContext, validationResults, true); //will return in validationResults 
            //all errors without stop
            //or and better in DbContext override metod SaveChanges() and validate there.

            make.Models.Add(model);

            db.SaveChanges();

            //shadow property :
            //var car = db.Cars.FirstOrDefault();
            //db.Entry(car).Property<int>("MySecretProperty").CurrentValue = 15;
        }
    }
}
