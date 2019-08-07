using CarSales_Mini.BLL.Interface;
using CarSales_Mini.BLL.Services;
using CarSales_Mini.Common.Helper;
using CarSales_Mini.Common.Model;
using CarSales_Mini.DAL.Entities;
using CarSales_Mini.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarSales_Mini.xUnitTest
{
    public class CarControllerTest
    {
        public CarControllerTest()
        {
           
        }

        [Fact]
        public async System.Threading.Tasks.Task Passing_GetAllAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CarSalesDbContext>().UseInMemoryDatabase(databaseName: "CarSales_Mini").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new CarSalesDbContext(options))
            {
                context.Vehicle.RemoveRange(await context.Vehicle.ToListAsync());
                context.SaveChanges();


                context.Vehicle.Add(GetCar("Toyota"));
                context.Vehicle.Add(GetCar("BMW"));
                context.Vehicle.Add(GetCar("Mec"));

                context.Vehicle.Add(GetBike("Bike1"));
                context.Vehicle.Add(GetBike("Bike2"));

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new CarSalesDbContext(options))
            {
                // Set
                var appSettings = Options.Create(new AppSettings { BikeController = "BikeService", CarController = "CarService" });

                List<IVehicleService> _vehicleService = new List<IVehicleService>();
                IVehicleService carService = new CarService(context);
                IVehicleService bikeService = new BikeService(context);
                _vehicleService.Add(carService);
                _vehicleService.Add(bikeService);


                CarController carController = new CarController(_vehicleService, appSettings);

                // Act
                var result = await carController.GetCarListAsync();

                var viewResult = Assert.IsType<ActionResult<List<Vehicle>>>(result);

                var model = Assert.IsAssignableFrom<List<Vehicle>>(viewResult.Value);

                // Assert
                Assert.Equal(3, model.Count());

            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Fail_GetAllAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CarSalesDbContext>().UseInMemoryDatabase(databaseName: "CarSales_Mini").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new CarSalesDbContext(options))
            {
                context.Vehicle.RemoveRange(await context.Vehicle.ToListAsync());
                context.SaveChanges();


                context.Vehicle.Add(GetCar("Toyota"));
                context.Vehicle.Add(GetCar("BMW"));
                context.Vehicle.Add(GetCar("Mec"));

                context.Vehicle.Add(GetBike("Bike1"));
                context.Vehicle.Add(GetBike("Bike2"));

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new CarSalesDbContext(options))
            {
                // Set
                var appSettings = Options.Create(new AppSettings { BikeController = "BikeService", CarController = "BikeService" });

                List<IVehicleService> _vehicleService = new List<IVehicleService>();
                IVehicleService carService = new CarService(context);
                IVehicleService bikeService = new BikeService(context);
                _vehicleService.Add(carService);
                _vehicleService.Add(bikeService);


                CarController carController = new CarController(_vehicleService, appSettings);

                // Act
                var result = await carController.GetCarListAsync();

                var viewResult = Assert.IsType<ActionResult<List<Vehicle>>>(result);

                var model = Assert.IsAssignableFrom<List<Vehicle>>(viewResult.Value);

                // Assert
                Assert.Equal(3, model.Count());

            }
        }

        private Car GetCar(string Make)
        {
            return new Car
            {
                UniqueId = StringHelper.RandomString(6),
                Make = Make,
                Model = "Avalon",
                Color = "White",
                Doors = 5,
                Engine = "Pulsar",
                Wheels = 4,
                BodyType = "Sedan",
                VehicleType = "Car",
                IsDeleted = false,
                CreatedBy = "test",
                CreatedOn = DateTime.Now,
            };
        }

        private Bike GetBike(string Type)
        {
            return new Bike
            {
                UniqueId = StringHelper.RandomString(6),
                Make = "Make",
                Model = "Model",
                Color = "Color",
                Type = Type,
                VehicleType = "Bike",
                IsDeleted = false,
                CreatedBy = "test",
                CreatedOn = DateTime.Now,
            };
        }

    }
}
