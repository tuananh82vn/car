using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;
using CarSales_Mini.Common.Helper;
using CarSales_Mini.Common.Model;

namespace CarSales_Mini.BLL.Services
{
    public class CarService: IVehicleService
    {

        private readonly CarSalesDbContext _dbContext;

        public CarService(CarSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrentName => nameof(CarService);

        /// <summary>    
        /// Add Car . Save data into Vehicle table.    
        /// </summary>
        public async Task<Vehicle> AddAsync(object viewModel)
        {
            var car = (Car)viewModel;

            car.UniqueId = StringHelper.RandomString(6);
            car.CreatedBy = "someone drive car";
            car.CreatedOn = DateTime.Now;

            _dbContext.Vehicle.Add(car);

            await _dbContext.SaveChangesAsync();

            return car;
        }


        /// <summary>    
        /// Edit Car . Update data into Vehicle table.    
        /// </summary>
        /// 
        public async Task<bool> EditAsync(object viewModel)
        {
            try
            {
                var car = (Car)viewModel;

                var originalModel = await _dbContext.Vehicle.OfType<Car>().Where(m=>m.Id == car.Id).FirstOrDefaultAsync();

                if (originalModel != null)
                {

                    originalModel.Make = car.Make;
                    originalModel.Model = car.Model;
                    originalModel.Color = car.Color;
                    originalModel.Engine = car.Engine;
                    originalModel.Doors = car.Doors;
                    originalModel.Wheels = car.Wheels;
                    originalModel.BodyType = car.BodyType;
                    originalModel.UpdatedBy = "someone driving car";
                    originalModel.UpdatedOn = DateTime.Now;

                    _dbContext.Vehicle.Update(originalModel);

                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }


        ///// <summary>    
        ///// Select All Car    
        ///// </summary>
        public async Task<List<Vehicle>> GetAllAsync()
        {
            var returnObject = await _dbContext.Vehicle.OfType<Car>().Where(m => !m.IsDeleted).ToListAsync();

            if (returnObject != null)
            {
                return returnObject.Cast<Vehicle>().ToList();
            }
            else
                return null;
        }

        ///// <summary>    
        ///// Select Car by UniqueId.    
        ///// </summary>
        public async Task<Vehicle> SelectAsync(string uniqueId)
        {
            var returnObject = await _dbContext.Vehicle.OfType<Car>().Where(m=>m.UniqueId == uniqueId).FirstOrDefaultAsync();

            if (returnObject != null)
            {
                return returnObject;
            }
            else
                return null;
        }


        ///// <summary>    
        ///// Delete data from Vehicle base on Id.    
        ///// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var vehicle = await _dbContext.Vehicle.OfType<Car>().Where(m => m.Id == id).FirstOrDefaultAsync();
                vehicle.IsDeleted = true;
                vehicle.UpdatedOn = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>    
        ///// Delete data from Vehicle base on Unique Id.    
        ///// </summary>
        //public async Task Delete(int id)
        //{
        //    await _vehicleEntity.Delete(id);
        //}

        ///// <summary>    
        ///// Get Data from Table   
        ///// </summary>
        //public IEnumerable<SelectListItem> GetVehicleListItems()
        //{
        //    var items = _vehicleEntity.GetVehicleList();

        //    var data = new List<SelectListItem>();

        //    SelectListItem EmptyListItem = new SelectListItem
        //    {
        //        Value = "",
        //        Text = "Select"
        //    };

        //    data.Add(EmptyListItem);
        //    foreach (var item in items)
        //    {
        //        data.Add(new SelectListItem
        //        {
        //            Value = item.Id.ToString(System.Globalization.CultureInfo.InvariantCulture),
        //            Text = item.Make
        //        });
        //    }

        //    return data;
        //}


    }
}
