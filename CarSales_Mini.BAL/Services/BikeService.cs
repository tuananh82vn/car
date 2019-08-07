using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;

namespace CarSales_Mini.BLL.Services
{
    public class BikeService: IVehicleService
    {

        private readonly CarSalesDbContext _dbContext;

        public BikeService(CarSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrentName => nameof(BikeService);

        /// <summary>    
        /// Add Bike . Save data into Vehicle table.    
        /// </summary>
        public async Task<Vehicle> AddAsync(object viewModel)
        {
            _dbContext.Vehicle.Add((Bike)viewModel);

            await _dbContext.SaveChangesAsync();

            return (Bike)viewModel;
        }


        /// <summary>    
        /// Edit Car . Update data into Vehicle table.    
        /// </summary>
        /// 
        public async Task<bool> EditAsync(object viewModel)
        {
            try
            {
                var bike = (Bike)viewModel;

                var originalModel = await _dbContext.Vehicle.OfType<Bike>().Where(m=>m.Id == bike.Id).FirstOrDefaultAsync();

                if (originalModel != null)
                {

                    originalModel.Make = bike.Make;
                    originalModel.Model = bike.Model;
                    originalModel.Color = bike.Color;
                    originalModel.Type = bike.Type;
                    originalModel.UpdatedBy = "someone driving bike";
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
            var returnObject = await _dbContext.Vehicle.OfType<Bike>().Where(m => !m.IsDeleted).ToListAsync();

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
            var returnObject = await _dbContext.Vehicle.OfType<Bike>().Where(m=>m.UniqueId == uniqueId).FirstOrDefaultAsync();

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
                var vehicle = await _dbContext.Vehicle.OfType<Bike>().Where(m => m.Id == id).FirstOrDefaultAsync();
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



        //public async Task<bool> SoftDelete(int id)
        //{
        //    return await _vehicleEntity.SoftDelete(id);
        //}

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
